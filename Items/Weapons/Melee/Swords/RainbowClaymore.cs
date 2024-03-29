using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords;

public class RainbowClaymore : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Spectrum");
		// Tooltip.SetDefault("[c/B6FF00:Autoswings] \nShoots three homing rainbow orbs in a large spread on swing");
	}

	public override void SetDefaults()
	{
		Item.damage = 185;
		Item.width = 60;
		Item.height = 68;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(3, 20, 0, 0);
		Item.rare = ItemRarityID.Expert;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.RainbowOrb>();
		Item.shootSpeed = 20f;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust>());
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust2>());
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust3>());
		}
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float numberProjectiles = 3f;
		float rotation = MathHelper.ToRadians(45f);
		position += Vector2.Normalize(velocity) * 45f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GoldenSlasher>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 14)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
