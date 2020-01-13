using Capi.DataObjects;
using System.Threading.Tasks;

namespace Capi.Interfaces
{



    public interface iCommand : ICommandRating, ICommandType
    {
        string Command { get; set; }
        Task<bool> Evaluate(iMsgData message);
        Task<object> DoWork(iMsgData md);
    }


}
