using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class OniSlayer : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Demon Slayer");
		Tooltip.SetDefault("[c/B6FF00:Autothrows]\nThrows 4 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.damage = 48;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 8;
		Item.useTime = 2;
		Item.width = 38;
		Item.height = 42;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.value = Item.sellPrice(0, 11, 85, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.shootSpeed = 30f;
		Item.reuseDelay = 12;
		Item.shoot = ModContent.ProjectileType<Projectiles.Shuriken.OniSlayer>();
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("FabusMod:CarbonShuriken", 1);
		val.AddRecipeGroup("FabusMod:AdamantiteBar", 6);
		val.AddIngredient(ItemID.Ruby, 3);
		val.AddIngredient(ItemID.SoulofNight, 3);
		val.AddTile(TileID.DemonAltar);
		val.Register();
	}
}
