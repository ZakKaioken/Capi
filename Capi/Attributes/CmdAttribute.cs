using System;

namespace Capi
{
    public class CmdAttribute : Attribute
    {
        public string command;
        public int commandRatings;
        public int commandType;

        public CmdAttribute(string command, int commandRatings, int commandType)
        {
            this.command = command;
            this.commandRatings = commandRatings;
            this.commandType = commandType;
        }
    }
}
