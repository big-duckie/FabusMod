using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.PetSummons;

public class SuspiciousFlower : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Suspicious Flower");
		Tooltip.SetDefault("[c/FFAF4F:Pet Summoning Item]\nI wonder who this flower belongs to? \n[c/46FFFF:~~ Developer Pet ~~]");
	}

	public override void SetDefaults()
	{
		Item.value = Item.buyPrice(0, 20, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.UseSound = SoundID.Item44;
		Item.shoot = ModContent.ProjectileType<Projectiles.Pets.WindUpFabu>();
		Item.buffType = ModContent.BuffType<Buffs.WindUpFabu>();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.AddBuff(Item.buffType, 3600, true);
		}
	}
}
