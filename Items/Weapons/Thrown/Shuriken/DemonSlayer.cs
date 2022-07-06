using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class DemonSlayer : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/B6FF00:Autothrows]\nThrows 4 fast-flying Shurikens at once");
	}

	public override void SetDefaults()
	{
		Item.damage = 48;
		Item.DamageType = DamageClass.Throwing;
		Item.maxStack = 1;
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
		CreateRecipe()
			.AddRecipeGroup("FabusMod:CarbonShuriken")
			.AddRecipeGroup("FabusMod:AdamantiteBar", 6)
			.AddIngredient(ItemID.Ruby, 3)
			.AddIngredient(ItemID.SoulofNight, 3)
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}
