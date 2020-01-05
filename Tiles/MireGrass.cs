using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ProjectMire.Tiles
{
	public class MireGrass : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true; // Is the tile solid
            Main.tileMergeDirt[Type] = true; // Will tile merge with dirt?
            Main.tileBlockLight[Type] = true; // Emits light
            Main.tileLighted[Type] = true; // ???
            drop = 59; // What tile will drop on kill
            AddMapEntry(new Color(32, 79, 46)); // (70, 80, 58), "Example Name"); Colour of tile on map
            SetModTree(new MangroveTree()); // Tree that grows from Acorns placed on tile
            // minPick = 40; Pick Power required to mine
        }

        public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

		public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("MireWaterfallStyle");
		}

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem){

            WorldGen.KillTile(i, j);
            WorldGen.PlaceTile(i, j, TileID.Mud);
        }

        public override int SaplingGrowthType(ref int style) {
			style = 0;
			return TileType<MangroveSapling>();
		}
	}
}