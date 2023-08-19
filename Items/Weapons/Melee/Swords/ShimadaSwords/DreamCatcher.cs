using FabusMod.Projectiles.Shimada;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class DreamCatcher : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/B6FF00:Autoswings]\nFires a beam of particles that ignores immunity frames, pierces 8 times, and regenerates 1 Mana with every hit\nInflicts [c/806580:Bad Dream] for 16 seconds when hit with the blade, dealing damage over time\n<right> uses 40 Mana to bring up [c/C4AB37:Midas]-inducing spikes from the ground, dealing damage with a 2% chance of granting a [c/FF52DC:Dream] stack\nHas a 10% chance to fire homing, soul-absorbing shards, healing for 20 HP and granting a stack of [c/FF52DC:Dream] when hit\nHaving 6 stacks of [c/FF52DC:Dream] restores 85 HP and Mana and puts you into an enraged state for 8 seconds, increasing melee damage dealt");
	}

	public override void SetDefaults()
	{
		Item.damage = 195;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 56;
		Item.height = 76;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(2, 75, 0, 0);
		Item.shoot = ModContent.ProjectileType<DreamCatcherWave>();
		Item.shootSpeed = 60f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.rare = ItemRarityID.Expert;
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.BadDream>(), 960, false);
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

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2 && player.velocity.Y == 0f)
		{
			Item.damage = 135;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.shootSpeed = 0f;
			Item.mana = 40;
			Item.shoot = ModContent.ProjectileType<DreamCatcherProjRMB>();
			Item.UseSound = SoundID.Item88;
		}
		else
		{
			Item.damage = 195;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.shootSpeed = 10f;
			Item.mana = 0;
			if (Utils.NextFloat(Main.rand) < 0.1f)
			{
				Item.shoot = ModContent.ProjectileType<DreamCatcherProjTwo>();
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<DreamCatcherWave>();
			}
			Item.UseSound = SoundID.Item1;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GoldenFury>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 10)
			.AddTile(null, "RainbowStation")
			.Register();
	}
}
