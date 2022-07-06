using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class GoldenVengeance : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Enemies are invulnerable for 4 frames after getting hit \nPurify your foes out of existence with a powerful laser beam! \nInflicts the [c/FFFB62:Holy Smite] debuff for 4 seconds, and the [c/DAD45E:Midas] debuff for 3 seconds on hit\n[c/FFFB62:Holy Smite] causes enemies to lose life quickly \n[c/DAD45E:Midas] causes enemies to drop more money on death");
	}

	public override void SetDefaults()
	{
		Item.damage = 48;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 10;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 20;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.GoldenBeam>();
		Item.value = Item.sellPrice(0, 27, 50, 0);
		Item.rare = ItemRarityID.Expert;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HeavensVengeance>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
