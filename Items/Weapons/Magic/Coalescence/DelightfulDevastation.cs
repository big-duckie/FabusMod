using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Coalescence;

public class DelightfulDevastation : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Enemies are invulnerable for 3 frames after getting hit \nVaporize your foes out of existence with the power of rainbows! \nInflicts the [c/AB2C2C:R][c/F3821B:a][c/E6AF31:i][c/63B465:n][c/82E8E8:b][c/9EF3EF:o][c/2BA0B5:w][c/734679:'s ][c/AB2C2C:W][c/F3821B:r][c/E6AF31:a][c/63B465:t][c/82E8E8:h] debuff for 2 seconds, and the [c/DAD45E:Midas] debuff for 3 seconds on hit\n[c/AB2C2C:R][c/F3821B:a][c/E6AF31:i][c/63B465:n][c/82E8E8:b][c/9EF3EF:o][c/2BA0B5:w][c/734679:'s ][c/AB2C2C:W][c/F3821B:r][c/E6AF31:a][c/63B465:t][c/82E8E8:h] causes enemies to lose life rapidly \n[c/DAD45E:Midas] causes enemies to drop more money on death ");
	}

	public override void SetDefaults()
	{
		Item.damage = 160;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.channel = true;
		Item.mana = 15;
		Item.width = 30;
		Item.height = 32;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 14f;
		Item.useAnimation = 10;
		Item.shoot = ModContent.ProjectileType<Projectiles.Lasers.RainbowBeam>();
		Item.value = Item.sellPrice(2, 40, 0, 0);
		Item.rare = ItemRarityID.Expert;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GoldenVengeance>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 10)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
