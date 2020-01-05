using ProjectMire.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ProjectMire.Tiles
{
	public class MangroveTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("ProjectMire");

		public override int CreateDust() {
			return DustType<Sparkle>();
		}

		public override int GrowthFXGore() {
			return mod.GetGoreSlot("Gores/MangroveTreeFX");
		}

		public override int DropWood() {
			return ItemType<Items.Placeable.MangroveWood>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/MireTree_Tiles");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/MireTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/MireTree_Branches");
		}
	}
}