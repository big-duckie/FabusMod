using FabusMod.Projectiles.LightBlasts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.LightGuns;

public class SpectralBlaster : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Spectral Blaster");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nDoesn't require ammo\nShoots rainbow blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 100;
		Item.width = 32;
		Item.height = 38;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(1, 55, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<RainbowLightBlast>();
		Item.shootSpeed = 10f;
		Item.expert = true;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 32f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<GoldenStinger>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
