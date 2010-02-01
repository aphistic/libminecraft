LibMinecraft
Written by: Erik Davidson
---
A C# library to read and write Minecraft levels.


Better documentation is coming soon! For now I'd recommend compiling this project
using Visual Studio, MonoDevelop or the Mono project's xbuild and using Red Gate's
excellent Reflector tool to take a look at the interfaces available.

The main "entry point" for the library is the McLevel class.  LibMinecraft relies
on LibNbt to read the mclevel files.  Once LibMinecraft loads the level it leaves
the LibNbt data for the garbage collector to free up memory usage.  Once the level
is being saved it recreates the NBT file and passes it to LibNbt to write out the
resulting file.

For an example of how to use this library to read a Minecraft level you may want to
look at the mciso utility at: http://github.com/aphistic/mciso

NOTES:
- The Entity classes are currently not finished.  They will read in the
underlying NBT data but will simply store that data and pass it back when saved.
This will allow library usage with the map data that is finished but still save
out a file that can be loaded into the Minecraft client.  Once these Entity
classes are finished they will function just like all the other strongly typed
data in the library.

- The usage of the TileEntities is currently unknown.  It was found in a
Minecraft level saved from a newer version of the game client.