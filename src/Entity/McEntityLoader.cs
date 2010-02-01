using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibNbt.Tags;

namespace LibMinecraft.Entity
{
    internal sealed class McEntityLoader
    {
        public static McEntity LoadEntity(NbtCompound entity)
        {
            if (entity["id"] != null && entity["id"] is NbtString)
            {
                switch (((NbtString) entity["id"]).Value.ToLower())
                {
                    case "mob":
                        McEntityMob mob = new McEntityMob();
                        mob.LoadEntity(entity);
                        return mob;
                    case "item":
                        McEntityItem item = new McEntityItem();
                        item.LoadEntity(entity);
                        return item;
                    case "localplayer":
                        McEntityLocalPlayer player = new McEntityLocalPlayer();
                        player.LoadEntity(entity);
                        return player;
                    default:
                        Console.WriteLine("Unknown Entity: {0}", ((NbtString) entity["id"]).Value);
                        break;
                }
            }
            return null;
        }
    }
}
