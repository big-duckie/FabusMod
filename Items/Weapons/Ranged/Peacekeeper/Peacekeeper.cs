using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Peacekeeper;

public class Peacekeeper : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Peacekeeper");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots]");
	}

	public override void SetDefaults()
	{
		Item.damage = 12;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 50;
		Item.height = 26;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 0, 60, 0);
		Item.rare = ItemRarityID.Blue;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 40f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -2f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 35f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddRecipeGroup("IronBar", 10);
		recipe.AddIngredient(ItemID.Sapphire, 2);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
