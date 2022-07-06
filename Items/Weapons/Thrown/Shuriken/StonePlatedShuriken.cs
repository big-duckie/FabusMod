using FabusMod.Projectiles.Shuriken;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Thrown.Shuriken;

public class StonePlatedShuriken : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Stone-Plated Shuriken");
		Tooltip.SetDefault("Does not consume on use");
	}

	public override void SetDefaults()
	{
		Item.damage = 9;
		Item.DamageType = DamageClass.Throwing;
		Item.maxStack = 1;
		Item.knockBack = 0f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;
		Item.useAnimation = 16;
		Item.useTime = 16;
		Item.width = 34;
		Item.height = 38;
		Item.consumable = false;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.autoReuse = false;
		Item.value = Item.sellPrice(0, 0, 5, 40);
		Item.rare = ItemRarityID.White;
		Item.shootSpeed = 9f;
		Item.shoot = ModContent.ProjectileType<StonePlatedShurikenProj>();
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.WeaponParts.UntreatedShurikenPart>())
			.AddIngredient(ItemID.StoneBlock, 3)
			.AddIngredient(ItemID.FallenStar)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>())
			.Register();
	}
}
