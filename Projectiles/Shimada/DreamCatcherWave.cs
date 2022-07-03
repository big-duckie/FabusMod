using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class DreamCatcherWave : ModProjectile
{
	private const int alphaReducation = 50;

	public override void SetDefaults()
	{
		Projectile.width = 13;
		Projectile.height = 13;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 6;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 100;
        AIType = 14;
	}

	public override void AI()
	{
		int num1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
		Dust obj = Main.dust[num1];
		obj.velocity *= 0f;
		Main.dust[num1].noGravity = true;
		int num2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
		Dust obj2 = Main.dust[num2];
		obj2.velocity *= 0f;
		Main.dust[num2].noGravity = true;
		int num3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
		Dust obj3 = Main.dust[num3];
		obj3.velocity *= 0f;
		Main.dust[num3].noGravity = true;
		int num4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
		Dust obj4 = Main.dust[num4];
		obj4.velocity *= 0f;
		Main.dust[num4].noGravity = true;
		int num5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
		Dust obj5 = Main.dust[num5];
		obj5.velocity *= 0f;
		Main.dust[num5].noGravity = true;
		int num6 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
		Dust obj6 = Main.dust[num6];
		obj6.velocity *= 0f;
		Main.dust[num6].noGravity = true;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Projectile.owner == Main.myPlayer)
		{
			Player player = Main.player[Projectile.owner];
			if (Main.myPlayer == player.whoAmI)
			{
				player.statMana++;
				player.ManaEffect(1);
			}
		}
		target.immune[Projectile.owner] = 0;
	}
}
