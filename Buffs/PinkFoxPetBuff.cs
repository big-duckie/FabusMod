using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FabusMod.Buffs;

public class PinkFoxPetBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Pink Fox Pet");
		// Description.SetDefault("A pink apple for a pink fox!");
		Main.buffNoTimeDisplay[Type] = true;
		Main.vanityPet[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.buffTime[buffIndex] = 18000;
		player.GetModPlayer<FabuPlayer>().foxPet = true;
		if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.PinkFoxPet>()] <= 0 && player.whoAmI == Main.myPlayer)
		{
			Projectile.NewProjectile(new EntitySource_Misc(""), player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.PinkFoxPet>(), 0, 0f, player.whoAmI);
		}
	}
}
