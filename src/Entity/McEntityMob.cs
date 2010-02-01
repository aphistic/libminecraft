using System;
using System.Collections.Generic;
using System.Text;

namespace LibMinecraft.Entity
{
    public class McEntityMob : McEntity
    {
        public override McEntityType GetEntityType() { return McEntityType.Mob; }
    }
}
