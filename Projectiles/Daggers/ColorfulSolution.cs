using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Projectiles.Daggers;

public class ColorfulSolution : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Colorful Solution");
	}

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 34;
		Projectile.aiStyle = 2;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
        AIType = 48;
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
		{
			targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
		}
		return projHitbox.Intersects(targetHitbox);
	}

	public override void Kill(int timeLeft)
	{
		SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		Vector2 position = Projectile.position;
		Vector2 rotVector = Utils.ToRotationVector2(Projectile.rotation - MathHelper.ToRadians(90f));
		_ = position + rotVector * 16f;
		int item = 0;
		if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
		{
			NetMessage.SendData(MessageID.KillProjectile);
		}
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

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (Main.rand.NextBool(1))
		{
			target.AddBuff(BuffID.Venom, 720, false);
		}
	}
}
