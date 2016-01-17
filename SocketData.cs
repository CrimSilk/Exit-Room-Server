using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exit_Room_Server
{
    class SocketData
    {
        public readonly string command;
        public readonly string timerseconds;
        public readonly string hint; 

        public SocketData(string command, string seconds, string hint)
        {
            this.command = command;
            this.timerseconds = seconds;
            this.hint = hint;
        }

    }
}
