using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Pets;

public class PinkFoxPet : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.CloneDefaults(111);
        AIType = 111;
		Main.projFrames[Projectile.type] = 8;
		Projectile.width = 70;
		Projectile.height = 48;
		Main.projPet[Projectile.type] = true;
	}

	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Pink Fox Pet");
	}

	public override bool PreAI()
	{
		Main.player[Projectile.owner].bunny = false;
		return true;
	}

	public override void AI()
	{
		Player obj = Main.player[Projectile.owner];
		FabuPlayer modPlayer = obj.GetModPlayer<FabuPlayer>();
		if (obj.dead)
		{
			modPlayer.pinkFoxPet = false;
		}
		if (modPlayer.pinkFoxPet)
		{
			Projectile.timeLeft = 2;
		}
	}
}
