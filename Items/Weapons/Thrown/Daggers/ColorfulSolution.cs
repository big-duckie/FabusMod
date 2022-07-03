using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Daggers;

public class ColorfulSolution : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Colorful Solution");
		Tooltip.SetDefault("Doesn't consume on use \n[c/B6FF00:Autothrows] \nInflicts [c/401440:Venom] for 12 seconds on hit");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 195;
		Item.knockBack = 3f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 3;
		Item.useTime = 3;
		Item.width = 22;
		Item.height = 44;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.value = Item.sellPrice(3, 0, 0, 0);
		Item.expert = true;
		Item.shootSpeed = 28f;
		Item.shoot = ModContent.ProjectileType<global::FabusMod.Projectiles.Daggers.ColorfulSolution>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.MagicDagger, 1);
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 14);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
