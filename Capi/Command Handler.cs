using Capi.Commands.CommandReciever;
using Capi.DataObjects;
using Capi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capi
{
    public class Command_Handler
    {
        public List<iCommandReciever> cr = new List<iCommandReciever>();
        public List<iCommand> StaticCommands = new List<iCommand>();
        public List<iCommand> commands = new List<iCommand>();

        public async Task Init()
        {
            var go = CRReflector.ReflectRecievers();

            foreach(var ee in go)
            {
                if (!ee.Update)
                {
                    StaticCommands.AddRange(ee.RecieveCommands().GetAwaiter().GetResult());
                    go.Remove(ee);
                }
            }
            cr = go;
            await Task.CompletedTask;
        }

       
        public async Task Reload()
        {
            commands.Clear();

            commands.AddRange(StaticCommands);
            foreach(var go in cr)
            {
                if (go.Update) commands.AddRange(go.RecieveCommands().GetAwaiter().GetResult());
            }
            await Task.CompletedTask;
        }
        public async Task<object> DoCommands(iMsgData md)
        {
            List<object> ooo = new List<object>();
            await Reload();

            foreach (iCommand command in commands)
            {
                bool b = await command.Evaluate(md);
                if (b)
                {
                    ooo.Add(await command.DoWork(md));
                }
            }

            return ooo;
        }


        
    }


}
