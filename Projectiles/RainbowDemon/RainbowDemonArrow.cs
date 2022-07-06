using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.RainbowDemon;

public class RainbowDemonArrow : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 18;
		Projectile.height = 34;
		Projectile.friendly = true;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = false;
		
		Projectile.timeLeft = 1000;
		Projectile.light = 1f;
        AIType = 1;
		Projectile.aiStyle = 1;
		Projectile.alpha = 0;
	}

	public override void AI()
	{
		if (Projectile.alpha > 30)
		{
			Projectile.alpha -= 15;
			if (Projectile.alpha < 30)
			{
				Projectile.alpha = 30;
			}
		}
		if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
		{
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
			Main.dust[dust1].velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;

			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
			Main.dust[dust2].scale = 0.9f;
			Main.dust[dust2].velocity *= 0.1f;
			Main.dust[dust2].noGravity = true;

			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
			Main.dust[dust1].scale = 0.9f;
			Main.dust[dust3].scale = 0.9f;
			Main.dust[dust3].velocity *= 0.1f;
			Main.dust[dust3].noGravity = true;
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
			{
				int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
				Main.dust[dust1].scale = 0.9f;
				Main.dust[dust1].velocity *= 0.1f;
				Main.dust[dust1].noGravity = true;

				int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
				Main.dust[dust2].scale = 0.9f;
				Main.dust[dust2].velocity *= 0.1f;
				Main.dust[dust2].noGravity = true;

				int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
				Main.dust[dust3].scale = 0.9f;
				Main.dust[dust3].velocity *= 0.1f;
				Main.dust[dust3].noGravity = true;
			}
		}
		SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
	}
}
