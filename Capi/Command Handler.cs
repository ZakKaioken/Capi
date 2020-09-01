using Capi.Commands.CommandReciever;
using Capi.DataObjects;
using Capi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
                     StaticCommands.AddRange(await ee.RecieveCommands());
                     go.Remove(ee);
                }
            }
            cr = go.ToList();
            await Task.CompletedTask;
        }
        
        public async Task<List<string>> GetHelp (iMsgData md)
        {
            await Reload();
            var list = new List<string>();
            foreach (var c in commands.ToList())
            {
                if (c.ShowHelp(md))
                {
                    list.Add(await c.toHelpString(md));
                }
            }
            return await Task.FromResult(list);
        }
       
        public async Task Reload()
        {
            commands.Clear();

            commands.AddRange(StaticCommands);
            foreach(var go in cr)
            {
                if (go.Update) commands.AddRange(await go.RecieveCommands());
            }
            await Task.CompletedTask;
        }

        public void Start(iMsgData md)
        {
            bCute(md).GetAwaiter().GetResult();
        }

        private async Task bCute(iMsgData md)
        {
            await Reload();
            await DoCommands(md);
        }

        private async Task DoCommands(iMsgData md)
        {
            foreach (iCommand command in commands.ToList())
            {
                await DoCommand(command, md);
                }
        }

        async Task DoCommand(iCommand command, iMsgData msgData)
        {
            if (command.Multithreaded)
            {
                Thread t = new Thread(async () =>
                {
                    var d = await command.Evaluate(msgData);
                    if (d)
                        await command.DoWork(msgData);
                }
                    );
                t.Start();
            }
            else
            {
                
                var d = await command.Evaluate(msgData);
                if (d)
                    await command.DoWork(msgData);
            }
        }
        }


    }



