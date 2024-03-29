using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class CarbonSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/B6FF00:Autoswings, dyeable]\nFires a stream of particles that deals damage three times\nInflicts [c/7B2D2F:Advanced Blood Loss] for 10 seconds when hit with the blade, dealing damage over time");
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
		Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.ShimadaWave>();
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 3;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(0f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RyuuDust2>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.AdvancedBloodLoss>(), 600, false);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShimadaSword>())
			.AddRecipeGroup("FabusMod:MythrilBar", 10)
			.AddTile(TileID.DemonAltar)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<CarbonSwordNihon>())
			.AddIngredient(ItemID.BlueDye, 1)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
