using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class HerosShuriken : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Hero's Shuriken");
		// Tooltip.SetDefault("Does not consume on use \nThrows 3 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.damage = 10;
		Item.DamageType = DamageClass.Throwing;
		Item.maxStack = 1;
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
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<StonePlatedShuriken>())
			.AddRecipeGroup("IronBar", 3)
			.AddIngredient(ItemID.Emerald)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
