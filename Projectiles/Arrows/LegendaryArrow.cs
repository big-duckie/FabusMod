using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Arrows;

public class LegendaryArrow : ModProjectile
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
	}

	public override void AI()
	{
		if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LegendaryDust>());
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LegendarySparkle>());
			Main.dust[dust].velocity /= 2f;
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (Main.rand.NextBool(1))
		{
			target.AddBuff(BuffID.Ichor, 900, false);
			target.AddBuff(BuffID.Venom, 900, false);
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LegendaryDust>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
		}
		for (int j = 0; j < 5; j++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LegendarySparkle>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
		}
		SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
	}
}
