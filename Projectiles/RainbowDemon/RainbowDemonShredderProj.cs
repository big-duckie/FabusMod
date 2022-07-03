using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.RainbowDemon;

public class RainbowDemonShredderProj : ModProjectile
{
	private const int alphaReducation = 25;

	public override void SetDefaults()
	{
		Projectile.width = 46;
		Projectile.height = 52;
		Projectile.aiStyle = 18;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
		Projectile.tileCollide = false;
        AIType = 274;
		Projectile.timeLeft = 200;
		Projectile.alpha = 255;
	}

	public override void AI()
	{
		if (Projectile.alpha > 30)
		{
			Projectile projectile = Projectile;
			projectile.alpha -= 15;
			if (Projectile.alpha < 30)
			{
				Projectile.alpha = 30;
			}
		}
		if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
		{
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 0.9f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
			Main.dust[dust2].scale = 0.9f;
			Dust obj2 = Main.dust[dust2];
			obj2.velocity *= 0.1f;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust3].scale = 0.9f;
			Dust obj3 = Main.dust[dust3];
			obj3.velocity *= 0.1f;
			Main.dust[dust3].noGravity = true;
		}
	}
}
