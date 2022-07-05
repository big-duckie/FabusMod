using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.IllusoryMirror;

public class IllusoryMirrorRMB : ModProjectile
{
	public override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 6;
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
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.HealingDust>());
			Main.dust[dust1].scale = 2f;
			Main.dust[dust1].velocity.Y -= 0.5f;
			Main.dust[dust1].velocity.X = 0f;
			Main.dust[dust1].noGravity = true;

			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.IllusoryMirrorRMBDust>());
			Main.dust[dust2].scale = 2f;
			Main.dust[dust2].velocity.Y += 0.5f;
			Main.dust[dust2].velocity.X = 0f;
			Main.dust[dust2].noGravity = true;
		}
		for (int i = 0; i < 255; i++)
		{
			Player player = Main.player[i];
			if (player.active && player.Distance(Projectile.Center) < 200f)
			{
				player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.StrongerTogether>(), 20, true);
			}
		}
	}

	public void AnimateProjectile()
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 7)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile projectile3 = Projectile;
			projectile3.frame %= 5;
			Projectile.frameCounter = 0;
		}
	}
}
