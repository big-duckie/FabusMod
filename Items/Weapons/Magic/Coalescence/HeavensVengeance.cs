using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class HeavensVengeance : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Heaven's Vengeance");
		Tooltip.SetDefault("Enemies are invulnerable for 4 frames after getting hit \nPurify your foes out of existence with a powerful laser beam! \nInflicts the [c/FFFB62:Holy Smite] debuff for 3 seconds on hit \n[c/FFFB62:Holy Smite] causes enemies to lose life quickly");
	}

	public override void SetDefaults()
	{
		Item.damage = 28;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 8;
		Item.expert = true;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 20;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.VengeanceBeam>();
		Item.value = Item.sellPrice(0, 16, 50, 0);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<HellfireBeam>(), 1);
		val.AddIngredient(ItemID.HallowedBar, 14);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
