using Capi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capi.Commands.CommandReciever
{
    public class CRReflector
    {
        public static List<iCommandReciever> ReflectRecievers()
        {
            var recievers = new List<iCommandReciever>();
            IEnumerable<Type> types = GetTypes(typeof(iCommandReciever));
            foreach (Type t in types)
            {
                object[] exa = t.GetCustomAttributes(typeof(CmdRecieverAttribute), true);
                foreach (CmdRecieverAttribute at in exa)
                {
                    iCommandReciever obj = (iCommandReciever)Activator.CreateInstance(t);
                    obj.Update = at.update;
                    recievers.Add(obj);
                }
            }

            return recievers;
        }
        public static IEnumerable<Type> GetTypes(Type t)
        {
            Type type = t;
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            return types;
        }
    }
}
