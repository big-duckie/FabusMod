using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class LunaticBand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Lunatic Charm");
		// Tooltip.SetDefault("14% increased all damage\nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 42;
		Item.value = Item.sellPrice(0, 20, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.accessory = true;
		Item.defense = 12;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Generic) += 0.14f;
		player.buffImmune[BuffID.OnFire] = true;
		player.buffImmune[BuffID.Obstructed] = true;
		player.buffImmune[BuffID.VortexDebuff] = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SolarBand>())
			.AddIngredient(ItemID.LunarBar, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<VortexBand>())
			.AddIngredient(ItemID.LunarBar, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<StardustBand>())
			.AddIngredient(ItemID.LunarBar, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<NebulaBand>())
			.AddIngredient(ItemID.LunarBar, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
