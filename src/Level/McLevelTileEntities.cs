using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibNbt.Tags;

namespace LibMinecraft.Level
{
    public class McLevelTileEntities
    {
        public McLevelTileEntities()
        {
        }

        internal void LoadSection(NbtTag section)
        {
            // Make sure we're passed a TAG_List named "TileEntities"
            if (section is NbtList && section.Name == "TileEntities")
            {
                //NbtList list = (NbtList) section;
            }
        }

        internal NbtTag SaveSection()
        {
            // Create the tags to save this section
            NbtList section = new NbtList("TileEntities");
            return section;
        }
    }
}
