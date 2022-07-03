using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Projectiles.Shuriken;

public class HerosShuriken : ModProjectile
{
	private const float maxTicks = 45f;

	private const int alphaReducation = 25;

	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hero's Shuriken");
	}

	public override void SetDefaults()
	{
		Projectile.width = 17;
		Projectile.height = 19;
		Projectile.aiStyle = 2;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
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
			NetMessage.SendData(MessageID.KillProjectile, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
		}
	}

	public override void AI()
	{
		if (Main.rand.NextBool(3))
		{
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RyuuDust>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 1f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
		}
	}
}
