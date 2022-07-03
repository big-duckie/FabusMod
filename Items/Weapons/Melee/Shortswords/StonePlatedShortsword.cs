using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class StonePlatedShortsword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Stone-Plated Shortsword");
	}

	public override void SetDefaults()
	{
		Item.damage = 9;
		Item.width = 30;
		Item.height = 30;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 0, 0, 40);
		Item.rare = ItemRarityID.White;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = false;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.WeaponParts.UntreatedShortswordPart>());
		val.AddIngredient(ItemID.StoneBlock, 6);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>());
		val.Register();
	}
}
