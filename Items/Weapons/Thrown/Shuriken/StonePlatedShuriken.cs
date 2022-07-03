using FabusMod.Projectiles.Shuriken;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class StonePlatedShuriken : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Stone-Plated Shuriken");
		Tooltip.SetDefault("Does not consume on use");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 9;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 16;
		Item.useTime = 16;
		Item.width = 34;
		Item.height = 38;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = false;
		Item.value = Item.sellPrice(0, 0, 5, 40);
		Item.rare = ItemRarityID.White;
		Item.shootSpeed = 9f;
		Item.shoot = ModContent.ProjectileType<StonePlatedShurikenProj>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.WeaponParts.UntreatedShurikenPart>());
		val.AddIngredient(ItemID.StoneBlock, 3);
		val.AddIngredient(ItemID.FallenStar, 1);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>());
		val.Register();
	}
}
