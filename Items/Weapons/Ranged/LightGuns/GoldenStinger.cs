using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.LightGuns;

public class GoldenStinger : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Stinger");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nDoesn't require ammo\nShoots golden light blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 68;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 32;
		Item.height = 38;
		Item.useTime = 3;
		Item.useAnimation = 3;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 30, 35, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.LightBlasts.GoldenLightBlast>();
		Item.shootSpeed = 10f;
		Item.rare = 12;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 32f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:TheStinger")
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
