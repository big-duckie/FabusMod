using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class SparklingDemon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sparkling Demon");
		Tooltip.SetDefault("[c/B6FF00:Autothrows]\nThrows 5 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 90;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 10;
		Item.useTime = 2;
		Item.width = 38;
		Item.height = 42;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.value = Item.sellPrice(0, 58, 50, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.shootSpeed = 30f;
		Item.reuseDelay = 12;
		Item.shoot = ModContent.ProjectileType<global::FabusMod.Projectiles.Shuriken.SparklingDemon>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<OniSlayer>());
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 6);
		val.AddTile(TileID.AdamantiteForge);
		val.Register();
	}
}
