using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class TheSpinningRainbow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Spinning Rainbow");
		Tooltip.SetDefault("[c/B6FF00:Autothrows]\nThrows 6 Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 230;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 12;
		Item.useTime = 2;
		Item.width = 28;
		Item.height = 28;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.value = Item.sellPrice(2, 70, 0, 0);
		Item.expert = true;
		Item.shootSpeed = 25f;
		Item.reuseDelay = 8;
		Item.shoot = ModContent.ProjectileType<Projectiles.TheSpinningRainbow>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<SparklingDemon>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
