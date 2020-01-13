using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capi.Interfaces;

namespace Capi.Commands.CommandReciever
{
    public class CmdReciever : iCommandReciever
    {
        public bool Update { get; set; }

        public virtual async Task<List<iCommand>> RecieveCommands()
        {
            var e = new List<iCommand>();
            await Task.Delay(0);
            return e;
        }
    }
}
