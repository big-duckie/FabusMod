using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class Coalescence : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Coalescence");
		Tooltip.SetDefault("Enemies are invulnerable for 8 frames after getting hit \nBeam your foes out of existence with a powerful laser beam!");
	}

	public override void SetDefaults()
	{
		Item.damage = 6;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 5;
		Item.expert = true;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 20;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.CoalescenceBeam>();
		Item.value = Item.sellPrice(0, 8, 50, 0);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.OminousBook>());
		val.AddIngredient(ItemID.Diamond, 5);
		val.AddIngredient(ItemID.Emerald, 5);
		val.AddIngredient(ItemID.Sapphire, 5);
		val.AddIngredient(ItemID.Ruby, 5);
		val.AddIngredient(ItemID.Topaz, 5);
		val.AddIngredient(ItemID.Amethyst, 5);
		val.AddRecipeGroup("FabusMod:DemoniteBar", 10);
		val.AddTile(TileID.Books);
		val.Register();
	}
}
