using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Projectiles.RainbowDemon;

public class RainbowDemonMelee : ModProjectile
{
	private const float maxTicks = 300f;

	public override void SetDefaults()
	{
		Projectile.width = 80;
		Projectile.height = 48;
		Projectile.aiStyle = 28;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
		Projectile.tileCollide = false;
		Projectile.timeLeft = 200;
		Projectile.alpha = 255;
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
		Vector2 position = Projectile.position;
		Vector2 rotVector = Utils.ToRotationVector2(Projectile.rotation - MathHelper.ToRadians(90f));
		int item = 0;
		if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
		{
			NetMessage.SendData(MessageID.KillProjectile);
		}
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
		if (Projectile.ai[0] == 0f)
		{
			Projectile.ai[1] += 1f;
			if (Projectile.ai[1] >= maxTicks)
			{
				float velXmult = 0.98f;
				float velYmult = 0.35f;
				Projectile.ai[1] = maxTicks;
				Projectile.velocity.X = Projectile.velocity.X * velXmult;
				Projectile.velocity.Y = Projectile.velocity.Y + velYmult;
			}
			Projectile.rotation = Utils.ToRotation(Projectile.velocity) + MathHelper.ToRadians(90f);
		}
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
}
