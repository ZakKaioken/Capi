using Capi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capi.Interfaces
{
    public interface iCommandReciever
    {
        public bool Update { get; set; }
        public Task<List<iCommand>> RecieveCommands();
    }
}
