using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Peacekeeper;

public class Unity : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Unity");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots 6 bullets in quick succession \n60% chance to not consume ammo \nConverts Musket Balls into homing rainbow bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 150;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 38;
		Item.height = 24;
		Item.useTime = 2;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(2, 26, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 100f;
		Item.reuseDelay = 12;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Expert;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -2f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.6f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 35f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		if (type == 14)
		{
			type = ModContent.ProjectileType<RainbowBullet>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<GoddessRevolver>());
		recipe.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 8);
		recipe.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		recipe.Register();
	}
}
