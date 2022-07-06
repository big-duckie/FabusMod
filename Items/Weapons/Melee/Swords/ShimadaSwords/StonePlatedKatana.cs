using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class StonePlatedKatana : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Stone-Plated Katana");
	}

	public override void SetDefaults()
	{
		Item.damage = 8;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 56;
		Item.height = 66;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 0, 0, 40);
		Item.rare = ItemRarityID.White;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.WeaponParts.UntreatedSwordParts>())
			.AddIngredient(ItemID.StoneBlock, 12)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>())
			.Register();
	}
}
