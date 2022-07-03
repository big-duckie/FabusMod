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
		Item.expert = true;
		Item.accessory = true;
		Item.defense = 26;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statManaMax2 += 120;
		player.statLifeMax2 += 120;
		player.GetDamage(DamageClass.Generic) += 0.3f;
		player.buffImmune[24] = true;
		player.buffImmune[164] = true;
		player.buffImmune[163] = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<HarmonyScarf>());
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.RainbowToken>());
		val.AddIngredient(ItemID.Sapphire, 15);
		val.AddIngredient(ItemID.Ruby, 15);
		val.AddIngredient(ItemID.Amethyst, 15);
		val.AddIngredient(ItemID.SoulofLight, 30);
		val.AddIngredient(ItemID.SoulofNight, 30);
		val.AddIngredient(ItemID.SoulofSight, 30);
		val.AddIngredient(ItemID.SoulofFright, 30);
		val.AddIngredient(ItemID.SoulofMight, 30);
		val.AddIngredient(ItemID.LunarBar, 20);
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 20);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
