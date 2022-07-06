using FabusMod.Buffs.ShimadaSword.Stacks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class DemonProjRMB : ModProjectile
{
	public override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 14;
	}

	public override void SetDefaults()
	{
		Projectile.width = 300;
		Projectile.height = 132;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 42;
		Projectile.alpha = 80;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 0;
		Projectile.velocity = Projectile.velocity * 0f;
	}

	public override void AI()
	{
		AnimateProjectile();
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.BloodDust>());
			Main.dust[dust].scale = 1.9f;
			Main.dust[dust].velocity.Y -= 1.5f;
			Main.dust[dust].velocity.X = 0f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Projectile.owner != Main.myPlayer)
		{
			return;
		}
		Player player = Main.player[Projectile.owner];
		if (!(Utils.NextFloat(Main.rand) < 0.02f))
		{
			return;
		}
		if (!player.HasBuff(ModContent.BuffType<SouleaterOne>()) && !player.HasBuff(ModContent.BuffType<SouleaterTwo>()) && !player.HasBuff(ModContent.BuffType<SouleaterThree>()) && !player.HasBuff(ModContent.BuffType<SouleaterFour>()) && !player.HasBuff(ModContent.BuffType<SouleaterFive>()))
		{
			player.AddBuff(ModContent.BuffType<SouleaterOne>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterOne>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterOne>());
			player.AddBuff(ModContent.BuffType<SouleaterTwo>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterTwo>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterTwo>());
			player.AddBuff(ModContent.BuffType<SouleaterThree>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterThree>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterThree>());
			player.AddBuff(ModContent.BuffType<SouleaterFour>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterFour>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterFour>());
			player.AddBuff(ModContent.BuffType<SouleaterFive>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterFive>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterFive>());
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

	public void AnimateProjectile()
	{
		Projectile.frameCounter++;
		if (Projectile.frameCounter >= 3)
		{
			Projectile.frame++;
			Projectile.frame %= 14;
			Projectile.frameCounter = 0;
		}
	}
}
