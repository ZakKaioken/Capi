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
        public List<iCommand> StaticCommands = new List<iCommand>();
        public List<iCommand> commands = new List<iCommand>();
        public async Task Init()
        {
            GetStaticCommandsThroughReflection();

            await Task.CompletedTask;
        }

        public void GetStaticCommandsThroughReflection()
        {
            IEnumerable<Type> types = GetTypes(typeof(iCommand));
            foreach (Type t in types)
            {
                object[] exa = t.GetCustomAttributes(typeof(CmdAttribute), true);
                foreach (CmdAttribute at in exa)
                {
                    iCommand obj = (iCommand)Activator.CreateInstance(t);
                    obj.command = at.command;
                    obj.Rating = (CommandRatings)at.commandRatings;
                    obj.Type = (CommandType)at.commandType;
                    StaticCommands.Add(obj);
                }
            }
        }

        public async Task Reload()
        {
            commands.Clear();

            commands.AddRange(StaticCommands);
            //gelbooru commands
            await Task.CompletedTask;
        }
        public async Task<object> DoCommands(MsgData md)
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


        private IEnumerable<Type> GetTypes(Type t)
        {
            Type type = t;
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            return types;
        }
    }


}
