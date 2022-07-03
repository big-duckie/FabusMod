using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class SoulofWisdom : ModItem
{
	public override void SetStaticDefaults()
	{
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(5, 4));
		DisplayName.SetDefault("Soul of Wisdom");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\n'The essence of everlasting knowledge'");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 28;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 2, 40, 0);
		Item.rare = ItemRarityID.Pink;
		//Sets.ItemNoGravity[Item.type] = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.SoulofFright, 1);
		val.AddIngredient(ItemID.SoulofMight, 1);
		val.AddIngredient(ItemID.SoulofSight, 1);
		val.AddTile(TileID.AdamantiteForge);
		val.Register();
	}
}
