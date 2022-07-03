using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class HarmonyScarf : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Harmony Scarf");
		Tooltip.SetDefault("Increases Max HP and Mana by 60\n20% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs \n'This would be a nice gift for a partner!'");
	}

	public override void SetDefaults()
	{
		Item.width = 42;
		Item.height = 38;
		Item.value = Item.sellPrice(5, 0, 0, 0);
		Item.expert = true;
		Item.accessory = true;
		Item.defense = 16;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statManaMax2 += 60;
		player.statLifeMax2 += 60;
		player.GetDamage(DamageClass.Generic) += 0.2f;
		player.buffImmune[24] = true;
		player.buffImmune[164] = true;
		player.buffImmune[163] = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<LunaticBand>());
		recipe.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.NatureToken>());
		recipe.AddIngredient(ItemID.LeafWand, 1);
		recipe.AddIngredient(ItemID.Emerald, 8);
		recipe.AddIngredient(ItemID.SoulofLight, 15);
		recipe.AddIngredient(ItemID.SoulofNight, 15);
		recipe.AddIngredient(ItemID.SoulofSight, 15);
		recipe.AddIngredient(ItemID.SoulofFright, 15);
		recipe.AddIngredient(ItemID.SoulofMight, 15);
		recipe.AddIngredient(ItemID.LunarBar, 8);
		recipe.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 8);
		recipe.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		recipe.Register();
	}
}
