using FabusMod.Projectiles.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class Kabuki : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Kabuki");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't use ammo \nAlways shoots Hellfire Arrows (except with <right>) \nPressing <right> fires 8 demonic arrows in quick succession, but it has lower damage and a 1.2 second cooldown");
	}

	public override void SetDefaults()
	{
		Item.damage = 42;
		Item.width = 18;
		Item.height = 38;
		Item.useTime = 14;
		Item.useAnimation = 14;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(0, 5, 40, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 18f;
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
			Item.useTime = 3;
			Item.useAnimation = 24;
			Item.damage = 38;
			Item.reuseDelay = 36;
			Item.shoot = ModContent.ProjectileType<DemonArrow>();
		}
		else
		{
			Item.reuseDelay = 0;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.damage = 42;
			Item.shoot = ProjectileID.HellfireArrow;
		}
		return CanUseItem(player);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<DemonsBow>());
		val.AddIngredient(ItemID.HallowedBar, 6);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
