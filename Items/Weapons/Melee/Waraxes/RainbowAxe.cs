using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Waraxes;

public class RainbowAxe : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Spectral Shredder");
		Tooltip.SetDefault("[c/B6FF00:Autoswings] \nPressing <right> fires a long-ranged Rainbow-Axe wall");
	}

	public override void SetDefaults()
	{
		Item.damage = 280;
		Item.DamageType = DamageClass.Melee;
		Item.width = 54;
		Item.height = 58;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.axe = 40;
		Item.tileBoost = 6;
		Item.knockBack = 8f;
		Item.value = Item.sellPrice(3, 20, 0, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.shootSpeed = 80f;
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

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.damage = 280;
			Item.axe = 38;
			Item.tileBoost = 6;
			Item.shoot = ModContent.ProjectileType<RainbowAxeBeam>();
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.damage = 280;
			Item.axe = 38;
			Item.tileBoost = 6;
			Item.shoot = ProjectileID.None;
		}
		return base.CanUseItem(player);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		float numberProjectiles = 16f;
		float rotation = MathHelper.ToRadians(35f);
		position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 80f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

    public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.LunarHamaxeSolar);
		recipe.AddIngredient(ItemID.LunarHamaxeVortex);
		recipe.AddIngredient(ItemID.LunarHamaxeNebula);
		recipe.AddIngredient(ItemID.LunarHamaxeStardust);
		recipe.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 14);
		recipe.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		recipe.Register();
	}
}
