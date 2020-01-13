namespace Capi.Interfaces
{
    enum CommandType
    {
        none = 0,
        pics = 1,
        fun = 2,
        admin = 3,
        owner = 4,
        utils = 5
    }
    interface ICommandType
    {
        public CommandType Type { get; set; }
    }
}