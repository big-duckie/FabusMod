using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class CarbonShuriken : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/B6FF00:Autothrows, dyeable]\nThrows 3 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.DamageType = DamageClass.Throwing;
		Item.damage = 19;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 9;
		Item.useTime = 3;
		Item.width = 30;
		Item.height = 28;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.value = Item.sellPrice(0, 1, 50, 0);
		Item.rare = ItemRarityID.Green;
		Item.shootSpeed = 30f;
		Item.reuseDelay = 14;
		Item.shoot = ModContent.ProjectileType<Projectiles.Shuriken.CarbonShuriken>();
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HerosShuriken>())
			.AddRecipeGroup("FabusMod:DemoniteBar", 3)
			.AddIngredient(ItemID.Sapphire)
			.AddTile(TileID.Anvils)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<CarbonShurikenNihon>())
			.AddIngredient(ItemID.BlueDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
