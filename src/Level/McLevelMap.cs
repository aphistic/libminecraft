
using System;

using LibNbt.Tags;

namespace LibMinecraft.Level
{
    public class McLevelMap
    {
        public short Width { get; set; }
        public short Height { get; set; }
        public short Length { get; set; }
		
        public MapData Blocks { get; protected set; }
        public MapData Data { get; protected set; }
		
        public Coordinates Spawn;
		
        internal McLevelMap()
        {
            Blocks = new MapData(this);
            Data = new MapData(this);
        }
		
        internal void LoadSection(NbtTag section)
        {
            // Make sure we're passed a TAG_Compound named "Map"
            if (section is NbtCompound && section.Name == "Map")
            {
                NbtCompound compound = (NbtCompound) section;
                Width = compound["Width"] != null ? ((NbtShort) compound["Width"]).Value : (short) 0;
                Height = compound["Height"] != null ? ((NbtShort) compound["Height"]).Value : (short) 0;
                Length = compound["Length"] != null ? ((NbtShort) compound["Length"]).Value : (short) 0;
                if (compound["Blocks"] != null)
                {
                    NbtByteArray blocks = (NbtByteArray) compound["Blocks"];
                    Blocks.Data = new byte[blocks.Value.Length];
                    Buffer.BlockCopy(blocks.Value, 0, Blocks.Data, 0, blocks.Value.Length);
                }
                else
                {
                    Blocks.Data = new byte[0];
                }
                if (compound["Data"] != null)
                {
                    NbtByteArray data = (NbtByteArray) compound["Data"];
                    Data.Data = new byte[data.Value.Length];
                    Buffer.BlockCopy(data.Value, 0, Data.Data, 0, data.Value.Length);
                }
                else
                {
                    Data.Data = new byte[0];
                }
                if (compound["Spawn"] != null && compound["Spawn"] is NbtList)
                {
                    NbtList list = (NbtList) compound["Spawn"];
                    Spawn.X = list.Tags.Count > 0 ? ((NbtShort) list.Tags[0]).Value : (short) 0;
                    Spawn.Y = list.Tags.Count > 1 ? ((NbtShort) list.Tags[1]).Value : (short) 0;
                    Spawn.Z = list.Tags.Count > 2 ? ((NbtShort) list.Tags[2]).Value : (short) 0;
                }
            }
        }
		
        internal NbtTag SaveSection()
        {
            // Create the tags to save this section
            NbtCompound section = new NbtCompound("Map");
            section.Tags.Add(new NbtShort("Width", Width));
            section.Tags.Add(new NbtShort("Height", Height));
            section.Tags.Add(new NbtShort("Length", Length));
            section.Tags.Add(new NbtByteArray("Blocks", Blocks.Data));
            section.Tags.Add(new NbtByteArray("Data", Data.Data));

            NbtList spawn = new NbtList("Spawn");
            spawn.Tags.Add(new NbtShort(Spawn.X));
            spawn.Tags.Add(new NbtShort(Spawn.Y));
            spawn.Tags.Add(new NbtShort(Spawn.Z));

            section.Tags.Add(spawn);
            return section;
        }
		
        public class MapData
        {
            private readonly McLevelMap _map;
			
            internal byte[] Data { get; set; }
			
            public byte this[int x, int y, int z]
            {
                get { return Data[x + (y*_map.Length + z)*_map.Width]; }
                set { Data[x + (y * _map.Length + z) * _map.Width] = value; }
            }
			
            internal MapData(McLevelMap map)
            {
                _map = map;
            }
        }
    }
}