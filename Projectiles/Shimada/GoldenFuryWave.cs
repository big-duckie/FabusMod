using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class GoldenFuryWave : ModProjectile
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
		int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.GoldenDust>());
		Main.dust[dust1].velocity *= 0f;
		Main.dust[dust1].noGravity = true;

		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.GoldenDust>());
		Main.dust[dust2].velocity *= 0f;
		Main.dust[dust2].noGravity = true;

		int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.GoldenDust>());
		Main.dust[dust3].velocity *= 0f;
		Main.dust[dust3].noGravity = true;

		int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.GoldenDust>());
		Main.dust[dust4].velocity *= 0f;
		Main.dust[dust4].noGravity = true;

		int dust5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.GoldenDust>());
		Main.dust[dust5].velocity *= 0f;
		Main.dust[dust5].noGravity = true;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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
