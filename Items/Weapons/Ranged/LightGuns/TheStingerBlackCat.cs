using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.LightGuns;

public class TheStingerBlackCat : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Stinger - Black Cat");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nDoesn't require ammo\nShoots little light blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 66;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 32;
		Item.height = 38;
		Item.useTime = 4;
		Item.useAnimation = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 13, 85, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.LightBlasts.LightBlast>();
		Item.shootSpeed = 5f;
		Item.rare = ItemRarityID.Pink;
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
			.AddIngredient(null, "TheStinger")
			.AddIngredient(ItemID.BlackDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
