using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class LunaticBand : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Lunatic Charm");
		Tooltip.SetDefault("14% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 42;
		Item.value = Item.sellPrice(0, 20, 0, 0);
		Item.rare = 12;
		Item.accessory = true;
		Item.defense = 12;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Generic) += 0.14f;
		player.buffImmune[24] = true;
		player.buffImmune[164] = true;
		player.buffImmune[163] = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<SolarBand>());
		val.AddIngredient(ItemID.LunarBar, 8);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();

		Recipe val2 = CreateRecipe();
		val2.AddIngredient(ModContent.ItemType<VortexBand>());
		val2.AddIngredient(ItemID.LunarBar, 8);
		val2.AddTile(TileID.LunarCraftingStation);
		val2.Register();

		Recipe val3 = CreateRecipe();
		val3.AddIngredient(ModContent.ItemType<StardustBand>());
		val3.AddIngredient(ItemID.LunarBar, 8);
		val3.AddTile(TileID.LunarCraftingStation);
		val3.Register();

		Recipe val4 = CreateRecipe();
		val4.AddIngredient(ModContent.ItemType<NebulaBand>());
		val4.AddIngredient(ItemID.LunarBar, 8);
		val4.AddTile(TileID.LunarCraftingStation);
		val4.Register();
	}
}
