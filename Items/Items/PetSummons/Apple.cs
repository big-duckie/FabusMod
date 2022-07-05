using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.PetSummons;

public class Apple : ModItem
{
	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.Carrot);
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.value = Item.buyPrice(0, 10, 0, 0);
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.shoot = ModContent.ProjectileType<Projectiles.Pets.FoxPet>();
		Item.buffType = ModContent.BuffType<Buffs.FoxPetBuff>();
	}

	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/B6FF00:Dyeable]\n[c/FFAF4F:Pet Summoning Item]\nSummons a fox to follow you around \n[c/FF2B6E:Currently Unobtainable]");
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.AddBuff(Item.buffType, 3600, true);
		}
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PinkApple>())
			.AddIngredient(ItemID.RedDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
