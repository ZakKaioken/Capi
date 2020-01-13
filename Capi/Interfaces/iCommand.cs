using Capi.DataObjects;
using System.Threading.Tasks;

namespace Capi.Interfaces
{



    interface iCommand : ICommandRating, ICommandType
    {
        string command { get; set; }
        Task<bool> Evaluate(MsgData message);
        Task<object> DoWork(MsgData md);
    }


}
