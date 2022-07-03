using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class HerosShuriken : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hero's Shuriken");
		Tooltip.SetDefault("Does not consume on use \nThrows 3 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 10;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 12;
		Item.useTime = 4;
		Item.width = 34;
		Item.height = 38;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = false;
		Item.value = Item.sellPrice(0, 0, 80, 0);
		Item.rare = ItemRarityID.Blue;
		Item.shootSpeed = 30f;
		Item.reuseDelay = 14;
		Item.shoot = ModContent.ProjectileType<Projectiles.Shuriken.HerosShuriken>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<StonePlatedShuriken>());
		val.AddRecipeGroup("IronBar", 3);
		val.AddIngredient(ItemID.Emerald, 1);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
