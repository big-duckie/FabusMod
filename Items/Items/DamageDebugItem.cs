using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items;

public class DamageDebugItem : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Damage Debug Item");
		Tooltip.SetDefault("Use to damage yourself by 100 HP\nUse <right> to heal by 100 HP\n[c/FF2B6E:Currently Unobtainable]");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 32;
		Item.useTime = 1;
		Item.useAnimation = 1;
		Item.maxStack = 1;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.value = Item.sellPrice(0, 0, 0, 0);
		Item.rare = ItemRarityID.Expert;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.altFunctionUse == 2)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.statLife += 100;
			}
		}
		else if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.statLife -= 100;
		}
	}
}
