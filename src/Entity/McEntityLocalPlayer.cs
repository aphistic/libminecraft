using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMinecraft.Entity
{
    public class McEntityLocalPlayer : McEntity
    {
        public override McEntityType GetEntityType() { return McEntityType.LocalPlayer; }
    }
}
