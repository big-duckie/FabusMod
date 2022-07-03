using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.IllusoryMirror;

public class SpectralIllusionRMB : ModProjectile
{
	public override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 8;
	}

	public override void SetDefaults()
	{
		Projectile.width = 400;
		Projectile.height = 360;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 1200;
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
			int num1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowHealingDust>(), 0f, 0f, 0, default, 1f);
			Main.dust[num1].scale = 2f;
			Main.dust[num1].velocity.Y -= 0.5f;
			Main.dust[num1].velocity.X = 0f;
			Main.dust[num1].noGravity = true;
			int num2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
			int num3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
			int num4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
			Main.dust[num2].scale = 2f;
			Main.dust[num2].velocity.Y += 0.5f;
			Main.dust[num2].velocity.X = 0f;
			Main.dust[num2].noGravity = true;
			Main.dust[num3].scale = 2f;
			Main.dust[num3].velocity.Y += 0.5f;
			Main.dust[num3].velocity.X = 0f;
			Main.dust[num3].noGravity = true;
			Main.dust[num4].scale = 2f;
			Main.dust[num4].velocity.Y += 0.5f;
			Main.dust[num4].velocity.X = 0f;
			Main.dust[num4].noGravity = true;
		}
		for (int i = 0; i < 255; i++)
		{
			Player player = Main.player[i];
			if (player.active && player.Distance(Projectile.Center) < 200f)
			{
				player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBloom>(), 20, true);
			}
		}
	}

	public void AnimateProjectile()
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 8)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile projectile3 = Projectile;
			projectile3.frame %= 7;
			Projectile.frameCounter = 0;
		}
	}
}
