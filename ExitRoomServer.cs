using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using PushSharp;
using PushSharp.Android;
using PushSharp.Core;
using System.Threading;
using System.Web.Script.Serialization;

namespace Exit_Room_Server
{
    public partial class ExitRoomServer : Form
    {

        private enum ClientCommand
        {
            START_TIMER,
            RESET_TIMER,
            STOP_TIMER,
            SYNC_TIMER,
            NEW_HINT, 
            STOP_GAME
        }

        private System.Windows.Forms.Timer countdownTimer;

        // Remaining time in seconds
        private long remainingTime;
        private bool timerPaused;

        private List<string> registrationIDList;
        private TcpListener tcpListener;

        private PushBroker pushBroker;

        public ExitRoomServer()
        {
            InitializeComponent();
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Tick += new EventHandler(timer_Tick);
            countdownTimer.Interval = 1000;

            registrationIDList = new List<string>();

            timerPaused = true;

            // PushSharp code implementation
            //Create our push services broker
            pushBroker = new PushBroker();

            //Wire up the events for all the services that the broker registers
            pushBroker.OnNotificationSent += NotificationSent;
            pushBroker.OnChannelException += ChannelException;
            pushBroker.OnServiceException += ServiceException;
            pushBroker.OnNotificationFailed += NotificationFailed;
            pushBroker.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            pushBroker.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            pushBroker.OnChannelCreated += ChannelCreated;
            pushBroker.OnChannelDestroyed += ChannelDestroyed;

            // Register server to GCM service
            pushBroker.RegisterGcmService(new GcmPushChannelSettings("AIzaSyBmNMdpaTiZsIT2Ty3xUxUbK025MeK6Apk"));

            // Start listening for client registrations
            CheckForIllegalCrossThreadCalls = false;
            String hostname = "";
            System.Net.IPHostEntry ip = new IPHostEntry();
            hostname = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostEntry(hostname);

            foreach (System.Net.IPAddress listip in ip.AddressList)
            {
                IPAddress ipAd = IPAddress.Parse(listip.ToString());
                int port = 4444;
                tcpListener = new TcpListener(ipAd, port);
                if (listip.AddressFamily == AddressFamily.InterNetwork)
                {
                    writeConsole("Server ip: " + listip);

                }
                writeConsole("Server listening to port: " + port);
                tcpListener.Start();
            }

            // Start listening for incoming data
            new Thread(connect).Start();
        }

        public void connect()
        {
            writeConsole("Waiting for connection request from clients");
            Socket serversocket;
            while (true)
            {
                serversocket = tcpListener.AcceptSocket();
                byte[] data_rec = new byte[1024];
                int k = serversocket.Receive(data_rec);
                writeConsole("Receiving client data");

                char cc;
                String mes = null;
                for (int i = 0; i < k - 1; i++)
                {
                    cc = Convert.ToChar(data_rec[i]);
                    mes += cc.ToString();
                }
                if (mes != null)
                {
                    writeConsole("Client connected - token: " + mes);
                    registrationIDList.Add(mes);
                    
                }
            }
        }

        private void sendNotification(ClientCommand command, long timeinseconds, string hint)
        {
            foreach (string registrationid in registrationIDList)
            {
                Console.Out.WriteLine("New notification sending");
                Console.Out.WriteLine("Command: " + command.ToString());
                Console.Out.WriteLine("Remaining seconds: " + timeinseconds.ToString());
                Console.Out.WriteLine("Hint: " + hint);

                writeConsole("New notification sending");
                writeConsole("Command: " + command.ToString());
                writeConsole("Remaining seconds: " + timeinseconds.ToString());
                writeConsole("Hint: " + hint);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                SocketData data = new SocketData(command.ToString(), timeinseconds.ToString(), hint);
                String jsonstring = serializer.Serialize(data);

                Console.Out.WriteLine("JsonString: " + jsonstring);
                
                pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(registrationid)
                                      .WithJson(jsonstring));
            }
            
           
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            updateTimer();
            // Sync time every 30 seconds
            if (remainingTime % 30 == 0)
            {
                sendNotification(ClientCommand.SYNC_TIMER, remainingTime, null);
            }
        }

        private void updateTimer()
        {
            countdownTimerLabel.Text = timeAsString(remainingTime);
        }

        private String timeAsString(long seconds)
        {
            long hour = ((remainingTime / 60) / 60) % 24;
            long min = (remainingTime / 60) % 60;
            long sec = remainingTime % 60;


            return String.Format("{0}:{1}:{2}", hour.ToString().PadLeft(2,'0'), min.ToString().PadLeft(2,'0'), sec.ToString().PadLeft(2,'0'));
        }

        public void writeConsole(String log)
        {
            logListBox.Items.Add(log);
            logListBox.TopIndex = logListBox.Items.Count - 1;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {

            if (timerPaused)
            {
                timerPaused = false;
                countdownTimer.Start();
                sendNotification(ClientCommand.START_TIMER, remainingTime, null);
            }
        }

        private void btnPauseGame_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            timerPaused = true;
            sendNotification(ClientCommand.STOP_TIMER, remainingTime, null);
        }

        private void btnStopGame_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            sendNotification(ClientCommand.STOP_GAME, 0, null);
        }

        private void btnEditTime_Click(object sender, EventArgs e)
        {
            EditTimerForm form = new EditTimerForm(remainingTime);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                remainingTime = form.totalSeconds; //values preserved after close
                updateTimer();
                sendNotification(ClientCommand.SYNC_TIMER, remainingTime, null);
            }
        }

        private void btnSendHint_Click(object sender, EventArgs e)
        {
            string hint = newHintTextBox.Text;
            newHintTextBox.Clear();
            sendNotification(ClientCommand.NEW_HINT, remainingTime, hint);
        }

        static void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
        {
            //Currently this event will only ever happen for Android GCM
            Console.WriteLine("Device Registration Changed:  Old-> " + oldSubscriptionId + "  New-> " + newSubscriptionId + " -> " + notification);
        }

        static void NotificationSent(object sender, INotification notification)
        {
            Console.WriteLine("Sent: " + sender + " -> " + notification);
        }

        static void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
        {
            Console.WriteLine("Failure: " + sender + " -> " + notificationFailureException.Message + " -> " + notification);
        }

        static void ChannelException(object sender, IPushChannel channel, Exception exception)
        {
            Console.WriteLine("Channel Exception: " + sender + " -> " + exception);
        }

        static void ServiceException(object sender, Exception exception)
        {
            Console.WriteLine("Service Exception: " + sender + " -> " + exception);
        }

        static void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
        {
            Console.WriteLine("Device Subscription Expired: " + sender + " -> " + expiredDeviceSubscriptionId);
        }

        static void ChannelDestroyed(object sender)
        {
            Console.WriteLine("Channel Destroyed for: " + sender);
        }

        static void ChannelCreated(object sender, IPushChannel pushChannel)
        {
            Console.WriteLine("Channel Created for: " + sender);
        }

        

        

        
    }
}
