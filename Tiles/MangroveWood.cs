using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ProjectMire.Tiles
{
    public class MangroveWood : ModTile
    {
        public override void SetDefaults() {
            Main.tileSolid[Type] = true; // Is the tile solid
            Main.tileMergeDirt[Type] = true; // Will tile merge with dirt?
            Main.tileBlockLight[Type] = false; // Emits light
            Main.tileLighted[Type] = true; // ???
            drop = ItemType<Items.Placeable.MangroveWood>(); // What tile will drop on kill
            AddMapEntry(new Color(70, 80, 58)); // (70, 80, 58), "Example Name"); Colour of tile on map
            // minPick = 40; Pick Power required to mine
        }


        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}
	}
}