using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace FabusMod.Tiles;

public class RainbowStation : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
		TileObjectData.addTile(Type);
        AnimationFrameHeight = 72;
		ModTranslation name = this.CreateMapEntryName(null);
		name.SetDefault("Rainbow Station");
        AddMapEntry(new Color(113, 85, 122), name);
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 0.9f;
		g = 0.1f;
		b = 0.5f;
	}

	public override void AnimateTile(ref int frame, ref int frameCounter)
	{
		frameCounter++;
		if (frameCounter > 4)
		{
			frameCounter = 0;
			frame++;
			frame %= 8;
		}
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_Misc(""), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Tiles.RainbowStation>(), 1, false, 0, false, false);
	}
}
