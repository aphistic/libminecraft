using System;

using LibNbt;
using LibNbt.Tags;

namespace LibMinecraft.Level
{
    public class McLevelAbout
    {	
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
		
        internal McLevelAbout()
        {
        }
		
        internal void LoadSection(NbtTag section)
        {
            // Make sure we're passed a TAG_Compound named "About"
            if (section is NbtCompound && section.Name == "About")
            {
                NbtCompound compound = (NbtCompound) section;
                Name = compound["Name"] != null ? ((NbtString) compound["Name"]).Value : "";
                Author = compound["Author"] != null ? ((NbtString) compound["Author"]).Value : "";
                if (compound["CreatedOn"] != null &&
                    compound["CreatedOn"] is NbtLong)
                {
                    CreatedOn = new DateTime(1970, 1, 1, 0, 0, 0, 0)
                        .AddMilliseconds(((NbtLong) compound["CreatedOn"]).Value);
                }
                else
                {
                    CreatedOn = DateTime.Now;
                }
            }
        }
		
        internal NbtTag SaveSection()
        {
            // Create the tags to save this section
            NbtCompound section = new NbtCompound("About");
            section.Tags.Add(new NbtString("Name", Name));
            section.Tags.Add(new NbtString("Author", Author));
            section.Tags.Add(new NbtLong("CreatedOn",
                                         (long) DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds));
			
            return section;
        }
    }
}