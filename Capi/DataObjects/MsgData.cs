namespace Capi.DataObjects
{
    public class MsgData : Interfaces.iMsgData
    {
        public string Message { get; set; }

        public MsgData(string Message)
        {
            this.Message = Message;
        }
    }
}
