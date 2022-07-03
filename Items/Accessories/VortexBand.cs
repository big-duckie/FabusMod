using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class VortexBand : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Vortex Band");
		Tooltip.SetDefault("12% increased ranged damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 36;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.accessory = true;
		Item.defense = 8;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Ranged) += 0.12f;
		player.buffImmune[24] = true;
		player.buffImmune[164] = true;
		player.buffImmune[163] = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<HallowedBand>());
		val.AddIngredient(ItemID.FragmentVortex, 6);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
