using FabusMod.Projectiles.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class RainBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Rain-Bow");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't use ammo \nAlways shoots two Rainbow Arrows in quick succession (except with <right>) \nPressing <right> fires 18 Holy Arrows in quick succession, but it has  lower damage and a 1 second cooldown");
	}

	public override void SetDefaults()
	{
		Item.damage = 90;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 30;
		Item.height = 50;
		Item.useTime = 3;
		Item.useAnimation = 6;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(1, 50, 0, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 20f;
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
			Item.useTime = 2;
			Item.useAnimation = 40;
			Item.damage = 84;
			Item.reuseDelay = 30;
			Item.shoot = ProjectileID.HolyArrow;
		}
		else
		{
			Item.reuseDelay = 0;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 3;
			Item.useAnimation = 6;
			Item.damage = 90;
			Item.shoot = ModContent.ProjectileType<RainbowArrow>();
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GoldenKabuki>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
