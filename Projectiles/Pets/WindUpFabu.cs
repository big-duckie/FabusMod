using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Pets;

public class WindUpFabu : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Wind-Up Fabu");
		Main.projFrames[Projectile.type] = 3;
		Main.projPet[Projectile.type] = true;
	}

	public override void SetDefaults()
	{
		Projectile.CloneDefaults(ProjectileID.Penguin);
		Projectile.width = 34;
		Projectile.height = 34;
        AIType = 112;
	}

	public override bool PreAI()
	{
		Main.player[Projectile.owner].penguin = false;
		return true;
	}

	public override void AI()
	{
		Player player = Main.player[Projectile.owner];
		FabuPlayer modPlayer = player.GetModPlayer<FabuPlayer>();
		if (player.dead)
		{
			modPlayer.fabu = false;
		}
		if (modPlayer.fabu)
		{
			Projectile.timeLeft = 2;
		}
	}
}
