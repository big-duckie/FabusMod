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
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RyuuDust2>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 1.9f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
		}
	}
}
