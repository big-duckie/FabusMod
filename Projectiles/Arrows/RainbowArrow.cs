using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Arrows;

public class RainbowArrow : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
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

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Main.rand.NextBool(1))
		{
			target.AddBuff(69, 900, false);
			target.AddBuff(70, 900, false);
		}
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
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
		SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
	}
}
