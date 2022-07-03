using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class HellfireBeam : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hellfire Beam");
		Tooltip.SetDefault("Enemies are invulnerable for 5 frames after getting hit \nBurn your foes out of existence with a powerful laser beam! \nInflicts the [c/DA0205:On Fire!] debuff for 2 seconds on hit");
	}

	public override void SetDefaults()
	{
		Item.damage = 17;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 7;
		Item.expert = true;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 20;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.HellfireBeamProj>();
		Item.value = Item.sellPrice(0, 12, 50, 0);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Coalescence>());
		val.AddIngredient(ItemID.HellstoneBar, 16);
		val.AddTile(TileID.Hellforge);
		val.Register();
	}
}
