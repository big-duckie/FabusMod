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
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowHealingDust>());
			Main.dust[dust1].scale = 2f;
			Main.dust[dust1].velocity.Y -= 0.5f;
			Main.dust[dust1].velocity.X = 0f;
			Main.dust[dust1].noGravity = true;

			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
			Main.dust[dust2].scale = 2f;
			Main.dust[dust2].velocity.Y += 0.5f;
			Main.dust[dust2].velocity.X = 0f;
			Main.dust[dust2].noGravity = true;

			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
			Main.dust[dust3].scale = 2f;
			Main.dust[dust3].velocity.Y += 0.5f;
			Main.dust[dust3].velocity.X = 0f;
			Main.dust[dust3].noGravity = true;

			int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
			Main.dust[dust4].scale = 2f;
			Main.dust[dust4].velocity.Y += 0.5f;
			Main.dust[dust4].velocity.X = 0f;
			Main.dust[dust4].noGravity = true;
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
		Projectile.frameCounter++;
		if (Projectile.frameCounter >= 8)
		{
			Projectile.frame++;
			Projectile.frame %= 7;
			Projectile.frameCounter = 0;
		}
	}
}
