using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class ShimadaWave : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 13;
		Projectile.height = 13;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
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
		if (Utils.NextFloat(Main.rand) < 0.5f)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RyuuDust2>());
			Main.dust[dust].scale = 1.9f;
			Main.dust[dust].velocity *= 0.1f;
			Main.dust[dust].noGravity = true;
		}
	}
}
