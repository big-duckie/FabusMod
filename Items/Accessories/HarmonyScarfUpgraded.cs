using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class HarmonyScarfUpgraded : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ultimate Scarf of Hope");
		Tooltip.SetDefault("Increases Max HP and Mana by 120\n30% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs \n'What else is left...?'");
	}

	public override void SetDefaults()
	{
		Item.width = 42;
		Item.height = 36;
		Item.value = Item.sellPrice(20, 0, 0, 0);
		Item.rare = ItemRarityID.Expert;
		Item.accessory = true;
		Item.defense = 26;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statManaMax2 += 120;
		player.statLifeMax2 += 120;
		player.GetDamage(DamageClass.Generic) += 0.3f;
		player.buffImmune[BuffID.OnFire] = true;
		player.buffImmune[BuffID.Obstructed] = true;
		player.buffImmune[BuffID.VortexDebuff] = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HarmonyScarf>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.RainbowToken>())
			.AddIngredient(ItemID.Sapphire, 15)
			.AddIngredient(ItemID.Ruby, 15)
			.AddIngredient(ItemID.Amethyst, 15)
			.AddIngredient(ItemID.SoulofLight, 30)
			.AddIngredient(ItemID.SoulofNight, 30)
			.AddIngredient(ItemID.SoulofSight, 30)
			.AddIngredient(ItemID.SoulofFright, 30)
			.AddIngredient(ItemID.SoulofMight, 30)
			.AddIngredient(ItemID.LunarBar, 20)
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 20)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
