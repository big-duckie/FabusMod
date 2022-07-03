using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.PetSummons;

public class PinkApple : ModItem
{
	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.Carrot);
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.value = Item.sellPrice(0, 5, 20, 0);
		Item.shoot = ModContent.ProjectileType<Projectiles.Pets.PinkFoxPet>();
		Item.buffType = ModContent.BuffType<Buffs.PinkFoxPetBuff>();
	}

	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Pink Apple");
		Tooltip.SetDefault("[c/B6FF00:Dyeable]\n[c/FFAF4F:Pet Summoning Item]\nSummons a pink fox to follow you around \n[c/FF2B6E:Currently Unobtainable]");
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
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Apple>());
		val.AddIngredient(ItemID.PinkDye);
		val.AddTile(TileID.DyeVat);
		val.Register();
	}
}
