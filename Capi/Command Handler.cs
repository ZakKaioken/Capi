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

        public Command_Handler()
        {
            Init().GetAwaiter().GetResult();
        }

        public async Task Init()
        {
            var go = CRReflector.ReflectRecievers();

            foreach(var ee in go.ToList())
            {
                if (!ee.Update)
                {
                    StaticCommands.AddRange(ee.RecieveCommands().GetAwaiter().GetResult());
                    go.Remove(ee);
                }
            }
            cr = go.ToList();
            await Task.CompletedTask;
        }

        public async Task<List<iCommand>> GetHelp (CommandRatings[] userratings)
        {
            await Reload();
            var list = new List<iCommand>();
            var urs = userratings;
            foreach (var c in commands.ToList())
            {
                if (urs.Contains(c.Rating))
                {
                    list.Add(c);
                }
            }
            var e = list;
            return await Task.FromResult(e);
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

            foreach (iCommand command in commands.ToList())
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
