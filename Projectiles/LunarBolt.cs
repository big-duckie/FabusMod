using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class LunarBolt : ModProjectile
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
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CrystalDust2>());
			Main.dust[dust].velocity /= 2f;
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CrystalDust2>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
		}
		SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
	}
}
