using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class StonePlatedBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Stone-Plated Bow");
		Tooltip.SetDefault("Doesn't use ammo\nAlways shoots Wooden Arrows");
	}

	public override void SetDefaults()
	{
		Item.damage = 5;
		Item.width = 18;
		Item.height = 38;
		Item.useTime = 32;
		Item.useAnimation = 32;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 0, 5, 60);
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = false;
		Item.shootSpeed = 9f;
		Item.shoot = ProjectileID.WoodenArrowFriendly;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.WeaponParts.UntreatedBowPart>(), 2);
		val.AddIngredient(ItemID.StoneBlock, 4);
		val.AddIngredient(ItemID.FallenStar, 1);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>());
		val.Register();
	}
}
