using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibMinecraft.Entity;
using LibNbt.Tags;

namespace LibMinecraft.Level
{
    public class McLevelEntities
    {
        public List<McEntity> Entities { get; set; }

        public McLevelEntities()
        {
            Entities = new List<McEntity>();
        }

        internal void LoadSection(NbtTag section)
        {
            // Make sure we're passed a TAG_List named "Entities"
            if (section is NbtList && section.Name == "Entities")
            {
                NbtList list = (NbtList) section;
                foreach (NbtTag tag in list.Tags)
                {
                    if (tag is NbtCompound)
                    {
                        McEntity entity = McEntityLoader.LoadEntity((NbtCompound) tag);
                        if (entity != null)
                        {
                            Entities.Add(entity);
                        }
                    }
                }
            }
        }

        internal NbtTag SaveSection()
        {
            // Create the tags to save this section
            NbtList section = new NbtList("Entities");
            foreach(McEntity entity in Entities)
            {
                section.Tags.Add(entity.SaveEntity());
            }
            return section;
        }
    }
}
