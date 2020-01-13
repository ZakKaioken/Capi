namespace Capi.Interfaces
{
    public enum CommandType
    {
        none = 0,
        pics = 1,
        fun = 2,
        admin = 3,
        owner = 4,
        utils = 5
    }
    public interface ICommandType
    {
        public CommandType Type { get; set; }
    }
}