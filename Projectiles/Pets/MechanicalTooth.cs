using Terraria;
using Terraria.ID;
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
		Projectile.CloneDefaults(ProjectileID.ZephyrFish);
		Projectile.width = 26;
		Projectile.height = 20;
        AIType = 380;
	}

	public override bool PreAI()
	{
		Main.player[Projectile.owner].zephyrfish = false;
		return true;
	}

	public override void AI()
	{
		Player player = Main.player[Projectile.owner];
		FabuPlayer modPlayer = player.GetModPlayer<FabuPlayer>();
		if (player.dead)
		{
			modPlayer.kregPet = false;
		}
		if (modPlayer.kregPet)
		{
			Projectile.timeLeft = 2;
		}
	}
}
