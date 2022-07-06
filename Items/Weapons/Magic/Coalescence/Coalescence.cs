using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class Coalescence : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Enemies are invulnerable for 8 frames after getting hit \nBeam your foes out of existence with a powerful laser beam!");
	}

	public override void SetDefaults()
	{
		Item.damage = 6;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 5;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 20;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.CoalescenceBeam>();
		Item.value = Item.sellPrice(0, 8, 50, 0);
		Item.rare = ItemRarityID.Expert;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.OminousBook>())
			.AddIngredient(ItemID.Diamond, 5)
			.AddIngredient(ItemID.Emerald, 5)
			.AddIngredient(ItemID.Sapphire, 5)
			.AddIngredient(ItemID.Ruby, 5)
			.AddIngredient(ItemID.Topaz, 5)
			.AddIngredient(ItemID.Amethyst, 5)
			.AddRecipeGroup("FabusMod:DemoniteBar", 10)
			.AddTile(TileID.Books)
			.Register();
	}
}
