using Command_API.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command_API
{
    class ExampleClass
    {
        Command_Handler ch = new Command_Handler();
        async Task ExampleMethod (string[] args)
        {
            ch.Init().GetAwaiter().GetResult();

            while (true)
            {
                string message = Console.ReadLine();
                MsgData md = new MsgData(message);

                object o = ch.DoCommands(md).GetAwaiter().GetResult();

                if (o is List<object> os)
                {
                    foreach (object oo in os)
                    {

                        if (oo is StringBuilder sb)
                        {
                            Console.WriteLine(sb.ToString());
                        } else
                        {
                            Console.WriteLine(oo.GetType());
                        }
                    }
                }

            }

        }

    }
}
