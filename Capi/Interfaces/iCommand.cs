using Capi.DataObjects;
using System.Threading.Tasks;

namespace Capi.Interfaces
{



    public interface iCommand : ICommandRating, ICommandType
    {
        string Command { get; set; }
        bool Multithreaded { get; set; }
        Task<bool> Evaluate(iMsgData message);
        Task DoWork(iMsgData md);
        Task<string> toHelpString(iMsgData md);
        bool ShowHelp(iMsgData md);
    }


}
