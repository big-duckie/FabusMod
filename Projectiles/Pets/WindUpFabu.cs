using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Pets;

public class WindUpFabu : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Wind-Up Fabu");
		Main.projFrames[Projectile.type] = 3;
		Main.projPet[Projectile.type] = true;
	}

	public override void SetDefaults()
	{
		Projectile.CloneDefaults(112);
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
		Player obj = Main.player[Projectile.owner];
		FabuPlayer modPlayer = obj.GetModPlayer<FabuPlayer>();
		if (obj.dead)
		{
			modPlayer.fabu = false;
		}
		if (modPlayer.fabu)
		{
			Projectile.timeLeft = 2;
		}
	}
}
