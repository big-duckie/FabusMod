using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shortsword;

public class Substitute : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 32;
		Projectile.height = 32;
		Projectile.friendly = true;
	}
}
