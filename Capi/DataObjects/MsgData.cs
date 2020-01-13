namespace Capi.DataObjects
{
    public class MsgData : Interfaces.IMsgData
    {
        public string Message { get; set; }

        public MsgData(string Message)
        {
            this.Message = Message;
        }
    }
}
