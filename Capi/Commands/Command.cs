using Command_API.DataObjects;
using Command_API.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace Command_API.Commands
{
    //[Cmd("!cmd", 1, 1)]
    class Command : iCommand
    {
        public string command { get; set; }
        public CommandRatings Rating { get; set; }
        public CommandType Type { get; set; }
        public async Task<object> DoWork(MsgData md)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(command);
            sb.Append(" used");
            await Task.CompletedTask;
            return sb;
        }

        public virtual async Task<bool> Evaluate(MsgData message)
        {
            bool b = message.Message.ToLower().Contains(command.ToLower());
            await Task.CompletedTask;
            return b;
        }

        public Command(string command, CommandRatings rating, CommandType type)
        {
            this.command = command;
            Rating = rating;
            Type = type;
        }

        public Command()
        {
            Console.WriteLine($"{GetType()} {command} cmd spawned");
        }
    }
}
