using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.PetSummons;

public class SuspiciousLookingScrew : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/FFAF4F:Pet Summoning Item]\nSummons Mechanical Teeth to follow you around \n[c/46FFFF:~~ Developer Pet ~~]");
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.ZephyrFish);
		Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MechanicalTooth>();
		Item.buffType = ModContent.BuffType<Buffs.MechanicalTooth>();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.AddBuff(Item.buffType, 3600, true);
		}
	}
}
