using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace FabusMod.Tiles;

public class ReinforcedWorkBench : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolidTop[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileTable[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = new[] { 18 };
		TileObjectData.addTile(Type);
		ModTranslation name = this.CreateMapEntryName(null);
		name.SetDefault("Reinforced Work Bench");
		AddMapEntry(new Color(120, 120, 120), name);
        AdjTiles = new int[1] { 18 };
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_Misc(""), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Tiles.ReinforcedWorkBench>(), 1, false, 0, false, false);
	}
}
