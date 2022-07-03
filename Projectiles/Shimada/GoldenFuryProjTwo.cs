using FabusMod.Buffs.ShimadaSword.Stacks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class GoldenFuryProjTwo : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 46;
		Projectile.height = 28;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		//Projectile.melee = true;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 2;
        AIType = 14;
	}

	public override void AI()
	{
		int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default, 1f);
		Main.dust[dust1].scale = 2f;
		Dust obj = Main.dust[dust1];
		obj.velocity *= 0.1f;
		Main.dust[dust1].noGravity = true;
		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default, 1f);
		Main.dust[dust2].scale = 2f;
		Dust obj2 = Main.dust[dust2];
		obj2.velocity *= 0.1f;
		Main.dust[dust2].noGravity = true;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Projectile.owner != Main.myPlayer)
		{
			return;
		}
		Player player = Main.player[Projectile.owner];
		if (!player.HasBuff(ModContent.BuffType<EnrichmentOne>()) && !player.HasBuff(ModContent.BuffType<EnrichmentTwo>()) && !player.HasBuff(ModContent.BuffType<EnrichmentThree>()) && !player.HasBuff(ModContent.BuffType<EnrichmentFour>()) && !player.HasBuff(ModContent.BuffType<EnrichmentFive>()))
		{
			player.AddBuff(ModContent.BuffType<EnrichmentOne>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<EnrichmentOne>()))
		{
			player.ClearBuff(ModContent.BuffType<EnrichmentOne>());
			player.AddBuff(ModContent.BuffType<EnrichmentTwo>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<EnrichmentTwo>()))
		{
			player.ClearBuff(ModContent.BuffType<EnrichmentTwo>());
			player.AddBuff(ModContent.BuffType<EnrichmentThree>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<EnrichmentThree>()))
		{
			player.ClearBuff(ModContent.BuffType<EnrichmentThree>());
			player.AddBuff(ModContent.BuffType<EnrichmentFour>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<EnrichmentFour>()))
		{
			player.ClearBuff(ModContent.BuffType<EnrichmentFour>());
			player.AddBuff(ModContent.BuffType<EnrichmentFive>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<EnrichmentFive>()))
		{
			player.ClearBuff(ModContent.BuffType<EnrichmentFive>());
			player.statLife += 75;
			player.statMana += 75;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(75, true);
				player.ManaEffect(75);
				SoundEngine.PlaySound(SoundID.Item3);
				SoundEngine.PlaySound(SoundID.Item4);
			}
		}
	}
}
