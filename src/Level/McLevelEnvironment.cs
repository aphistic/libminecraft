using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LibNbt.Tags;

namespace LibMinecraft.Level
{
    public class McLevelEnvironment
    {
        public short SurroundingGroundHeight { get; set; }
        public McBlock SurroundingGroundType { get; set;}
        public short SurroundingWaterHeight { get; set;}
        public McBlock SurroundingWaterType { get; set;}
        public short CloudHeight { get; set;}
        public Color CloudColor { get; set;}
        public Color SkyColor { get; set;}
        public Color FogColor { get; set;}
        public byte SkyBrightness { get; set;}

        internal McLevelEnvironment()
        {
        }
		
        internal void LoadSection(NbtTag section)
        {
            // Make sure we're passed a TAG_Compound named "Environment"
            if (section is NbtCompound && section.Name == "Environment")
            {
                NbtCompound compound = (NbtCompound) section;
                SurroundingGroundHeight = compound["SurroundingGroundHeight"] != null
                                              ? ((NbtShort) compound["SurroundingGroundHeight"]).Value
                                              : (short) 0;
                SurroundingGroundType = compound["SurroundingGroundType"] != null
                                            ? (McBlock) ((NbtByte) compound["SurroundingGroundType"]).Value
                                            : 0x00;
                SurroundingWaterHeight = compound["SurroundingWaterHeight"] != null
                                             ? ((NbtShort) compound["SurroundingWaterHeight"]).Value
                                             : (short) 0;
                SurroundingWaterType = compound["SurroundingWaterType"] != null
                                           ? (McBlock) ((NbtByte) compound["SurroundingWaterType"]).Value
                                           : 0x00;
                CloudHeight = compound["CloudHeight"] != null
                                  ? ((NbtShort) compound["CloudHeight"]).Value
                                  : (short) 0;
                CloudColor = compound["CloudColor"] != null
                                 ? Color.FromArgb(((NbtInt) compound["CloudColor"]).Value)
                                 : Color.Black;
                SkyColor = compound["SkyColor"] != null
                               ? Color.FromArgb(((NbtInt) compound["SkyColor"]).Value)
                               : Color.Black;
                FogColor = compound["FogColor"] != null
                               ? Color.FromArgb(((NbtInt) compound["FogColor"]).Value)
                               : Color.Black;
                SkyBrightness = compound["SkyBrightness"] != null
                                    ? ((NbtByte) compound["SkyBrightness"]).Value
                                    : (byte) 0x00;
            }
        }
		
        internal NbtTag SaveSection()
        {
            // Create the tags to save this section
            NbtCompound section = new NbtCompound("Environment");
            section.Tags.Add(new NbtShort("SurroundingGroundHeight", SurroundingGroundHeight));
            section.Tags.Add(new NbtByte("SurroundingGroundType", (byte) SurroundingGroundType));
            section.Tags.Add(new NbtShort("SurroundingWaterHeight", SurroundingWaterHeight));
            section.Tags.Add(new NbtByte("SurroundingWaterType", (byte) SurroundingWaterType));
            section.Tags.Add(new NbtShort("CloudHeight", CloudHeight));
            section.Tags.Add(new NbtInt("CloudColor", CloudColor.ToArgb()));
            section.Tags.Add(new NbtInt("SkyColor", SkyColor.ToArgb()));
            section.Tags.Add(new NbtInt("FogColor", FogColor.ToArgb()));
            section.Tags.Add(new NbtByte("SkyBrightness", SkyBrightness));
            return section;
        }
    }
}
