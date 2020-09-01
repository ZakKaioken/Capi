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
                await ch.DoCommands(md);

            }

        }

    }
}
