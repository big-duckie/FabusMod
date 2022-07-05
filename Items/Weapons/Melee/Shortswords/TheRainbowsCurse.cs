using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class TheRainbowsCurse : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Rainbow's Curse");
		Tooltip.SetDefault("[c/B6FF00:Autoswings]\nThrows three medium-ranged rainbow knives in any direction, as well as one very fast dagger \nShortsword hits steal a small amount of life, and inflict the [c/007700:Poison] debuff for 12 seconds\nRainbow knives do not steal life \nGrants the [c/FC3A3A:Rage] buff for 10 seconds, and the [c/FC8719:Inferno] buff for 8 seconds upon hitting an enemy with the Shortsword");
	}

	public override void SetDefaults()
	{
		Item.damage = 154;
		Item.DamageType = DamageClass.Melee;
		Item.width = 48;
		Item.height = 48;
		Item.useTime = 8;
		Item.useAnimation = 8;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(2, 20, 0, 0);
		Item.expert = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.Shortsword.RainbowKnife>();
		Item.shootSpeed = 65f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust>());
			Main.dust[dust1].scale = 1f;
			Main.dust[dust1].velocity.Y = 0f;
			Main.dust[dust1].velocity.X = 0.5f;
			Main.dust[dust1].noGravity = true;

			int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust2>());
			Main.dust[dust2].scale = 1f;
			Main.dust[dust2].velocity.Y = 0f;
			Main.dust[dust2].velocity.X = 0.5f;
			Main.dust[dust2].noGravity = true;

			int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RainbowDust3>());
			Main.dust[dust3].scale = 1f;
			Main.dust[dust3].velocity.Y = 0f;
			Main.dust[dust3].velocity.X = 0.5f;
			Main.dust[dust3].noGravity = true;
		}
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		float numberProjectiles = 3f;
		float rotation = MathHelper.ToRadians(6f);
		position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 6f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 60f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmount = damage / 16;
		player.statLife += healingAmount;
		player.HealEffect(healingAmount, true);
		target.AddBuff(20, 720, false);
		player.AddBuff(115, 600, true);
		player.AddBuff(116, 480, true);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<GoldenDagger>());
		recipe.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6);
		recipe.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		recipe.Register();
	}
}
