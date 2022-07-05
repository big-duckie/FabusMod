using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.IllusoryMirror;

public class SpectralIllusionProj : ModProjectile
{
    public override void SetDefaults()
	{
		Projectile.width = 2;
		Projectile.height = 20;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 100;
	}

	public override void AI()
	{
		int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SpectralIllusionDust>());
		Main.dust[dust1].velocity *= 0f;
		Main.dust[dust1].noGravity = true;

		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SpectralIllusionDust2>());
		Main.dust[dust2].velocity *= 0f;
		Main.dust[dust2].noGravity = true;

		int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SpectralIllusionDust3>());
		Main.dust[dust3].velocity *= 0f;
		Main.dust[dust3].noGravity = true;

		int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SpectralIllusionDust4>());
		Main.dust[dust4].velocity *= 0f;
		Main.dust[dust4].noGravity = true;

		int dust5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SpectralIllusionDust4>());
		Main.dust[dust5].velocity *= 0f;
		Main.dust[dust5].noGravity = true;
	}
}
