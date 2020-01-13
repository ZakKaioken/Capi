using Capi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capi.Commands.CommandReciever
{
    [CmdReciever(false)]
    public class ReflectionReciever : CmdReciever
    {
        public override async Task<List<iCommand>> RecieveCommands()
        {
            var StaticCommands = new List<iCommand>();
            IEnumerable<Type> types = GetTypes(typeof(iCommand));
            foreach (Type t in types)
            {
                object[] exa = t.GetCustomAttributes(typeof(CmdAttribute), true);
                foreach (CmdAttribute at in exa)
                {
                    iCommand obj = (iCommand)Activator.CreateInstance(t);
                    obj.Command = at.command;
                    obj.Rating = (CommandRatings)at.commandRatings;
                    obj.Type = (CommandType)at.commandType;
                    StaticCommands.Add(obj);
                }
            }
            
            return await Task.FromResult(StaticCommands); 
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
