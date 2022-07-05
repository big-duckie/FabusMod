using FabusMod.Projectiles.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class DemonsBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Demon's Bow");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't use ammo \nAlways shoots Hellfire Arrows (except with <right>) \nPressing <right> fires 6 demonic arrows in quick succession, but it has lower damage and a 2 second cooldown");
	}

	public override void SetDefaults()
	{
		Item.damage = 34;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 18;
		Item.height = 38;
		Item.useTime = 16;
		Item.useAnimation = 16;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
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
			Item.damage = 30;
			Item.reuseDelay = 60;
			Item.shoot = ModContent.ProjectileType<DemonArrow>();
		}
		else
		{
			Item.reuseDelay = 0;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.damage = 34;
			Item.shoot = ProjectileID.HellfireArrow;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<StormBow>())
			.AddIngredient(ModContent.ItemType<StonePlatedBow>())
			.AddIngredient(ItemID.HellstoneBar, 6)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
