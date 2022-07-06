using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.FoxPistol;

public class BlueBolt : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 2;
        AIType = 14;
	}

	public override void AI()
	{
		Projectile.velocity.Y += Projectile.ai[0];
		if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.FoxDustBlue>());
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].velocity *= 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.FoxDustBlue>());
				Main.dust[dust].scale = 0.9f;
				Main.dust[dust].velocity *= 0.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
