using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class SpectralMoonBolt : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.friendly = true;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = true;
		
		Projectile.timeLeft = 600;
		Projectile.light = 1f;
		Projectile.penetrate = 1;
        AIType = 1;
		Projectile.aiStyle = 1;
	}

	public override void AI()
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

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
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
		SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
	}
}
