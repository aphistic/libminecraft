
using System;
using LibMinecraft.Level;
using LibNbt;
using LibNbt.Tags;

namespace LibMinecraft
{
    public class McLevel : NbtFile
    {
        public McLevelAbout About { get; protected set; }
        public McLevelMap Map { get; protected set; }
        public McLevelEnvironment Environment { get; protected set; }
        public McLevelEntities Entities { get; protected set; }
        public McLevelTileEntities TileEntities { get; protected set; }
		
        public McLevel()
        {
            About = new McLevelAbout();
            Map = new McLevelMap();
            Environment = new McLevelEnvironment();
            Entities = new McLevelEntities();
            TileEntities = new McLevelTileEntities();
        }
        public McLevel(string fileName) : base(fileName)
        {
            About = new McLevelAbout();
            Map = new McLevelMap();
            Environment = new McLevelEnvironment();
            Entities = new McLevelEntities();
            TileEntities = new McLevelTileEntities();
        }
		
        public override void LoadFile()
        {
            LoadFile(LoadedFile);
        }
        public override void LoadFile(string fileName)
        {
            base.LoadFile(fileName);

            if (RootTag != null && RootTag.Name == "MinecraftLevel")
            {
                if (RootTag["About"] != null && RootTag["About"] is NbtCompound)
                {
                    About.LoadSection(RootTag["About"]);
                }
                if (RootTag["Map"] != null && RootTag["Map"] is NbtCompound)
                {
                    Map.LoadSection(RootTag["Map"]);
                }
                if (RootTag["Environment"] != null && RootTag["Environment"] is NbtCompound)
                {
                    Environment.LoadSection(RootTag["Environment"]);
                }
                if (RootTag["Entities"] != null && RootTag["Entities"] is NbtList)
                {
                    Entities.LoadSection(RootTag["Entities"]);
                }
                if (RootTag["TileEntities"] != null && RootTag["TileEntities"] is NbtList)
                {
                    TileEntities.LoadSection(RootTag["TileEntities"]);
                }
            }
			
            // Once loading is complete dump the RootTag to free up that memory.
            RootTag = null;
        }

        public override void SaveFile(string fileName)
        {
            RootTag = new NbtCompound("MinecraftLevel");

            RootTag.Tags.Add(About.SaveSection());
            RootTag.Tags.Add(Map.SaveSection());
            RootTag.Tags.Add(Environment.SaveSection());
            RootTag.Tags.Add(Entities.SaveSection());
            RootTag.Tags.Add(TileEntities.SaveSection());

            base.SaveFile(fileName);
            
            RootTag = null;
        }
    }
}