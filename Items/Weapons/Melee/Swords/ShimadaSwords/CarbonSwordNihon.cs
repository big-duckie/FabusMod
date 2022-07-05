using FabusMod.Projectiles.Shimada;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class CarbonSwordNihon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Carbon Sword - Nihon");
		Tooltip.SetDefault("[c/B6FF00:Autoswings, dyeable]\nFires a stream of particles that deals damage three times\nInflicts [c/7B2D2F:Advanced Blood Loss] for 10 seconds when hit with the blade, dealing damage over time");
	}

	public override void SetDefaults()
	{
		Item.damage = 74;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 54;
		Item.height = 68;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.shoot = ModContent.ProjectileType<ShimadaWaveNihon>();
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int numberProjectiles = 3;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(0f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.AdvancedBloodLoss>(), 600, false);
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.NightsAxeSparkle>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<CarbonSword>());
		recipe.AddIngredient(ItemID.SilverDye, 1);
		recipe.AddTile(TileID.DyeVat);
		recipe.Register();
	}
}
