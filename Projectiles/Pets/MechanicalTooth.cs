using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Pets;

public class MechanicalTooth : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Mechanical Tooth");
		Main.projFrames[Projectile.type] = 4;
		Main.projPet[Projectile.type] = true;
	}

	public override void SetDefaults()
	{
		Projectile.width = 26;
		Projectile.height = 20;
		Projectile.CloneDefaults(380);
        AIType = 380;
	}

	public override bool PreAI()
	{
		Main.player[Projectile.owner].zephyrfish = false;
		return true;
	}

	public override void AI()
	{
		Player obj = Main.player[Projectile.owner];
		FabuPlayer modPlayer = obj.GetModPlayer<FabuPlayer>();
		if (obj.dead)
		{
			modPlayer.kregPet = false;
		}
		if (modPlayer.kregPet)
		{
			Projectile.timeLeft = 2;
		}
	}
}
