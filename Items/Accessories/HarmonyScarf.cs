using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class HarmonyScarf : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Increases Max HP and Mana by 60\n20% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs \n'This would be a nice gift for a partner!'");
	}

	public override void SetDefaults()
	{
		Item.width = 42;
		Item.height = 38;
		Item.value = Item.sellPrice(5, 0, 0, 0);
		Item.rare = ItemRarityID.Expert;
		Item.accessory = true;
		Item.defense = 16;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statManaMax2 += 60;
		player.statLifeMax2 += 60;
		player.GetDamage(DamageClass.Generic) += 0.2f;
		player.buffImmune[BuffID.OnFire] = true;
		player.buffImmune[BuffID.Obstructed] = true;
		player.buffImmune[BuffID.VortexDebuff] = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<LunaticBand>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.NatureToken>())
			.AddIngredient(ItemID.LeafWand)
			.AddIngredient(ItemID.Emerald, 8)
			.AddIngredient(ItemID.SoulofLight, 15)
			.AddIngredient(ItemID.SoulofNight, 15)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ItemID.SoulofFright, 15)
			.AddIngredient(ItemID.SoulofMight, 15)
			.AddIngredient(ItemID.LunarBar, 8)
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 8)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
