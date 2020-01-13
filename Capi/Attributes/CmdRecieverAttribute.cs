using System;
using System.Collections.Generic;
using System.Text;

namespace Capi
{
    public class CmdRecieverAttribute : Attribute
    {
        public bool update;

        public CmdRecieverAttribute(bool update)
        {
            this.update = update;
        }
    }
}
