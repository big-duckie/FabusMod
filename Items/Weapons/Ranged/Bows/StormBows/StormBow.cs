using FabusMod.Projectiles.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class StormBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Storm Bow");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't use ammo \nAlways shoots Wooden Arrows (except with <right>) \nPressing <right> fires 6 Storm Arrows in quick succession, but it has lower damage and a 3 second cooldown");
	}

	public override void SetDefaults()
	{
		Item.damage = 24;
		Item.width = 18;
		Item.height = 38;
		Item.useTime = 18;
		Item.useAnimation = 18;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 0, 60, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 16f;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 4;
			Item.useAnimation = 24;
			Item.damage = 24;
            Item.reuseDelay = 90;
			Item.shoot = ModContent.ProjectileType<StormArrow>();
		}
		else
		{
			Item.reuseDelay = 0;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.damage = 28;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
		}
		return CanUseItem(player);
	}
}
