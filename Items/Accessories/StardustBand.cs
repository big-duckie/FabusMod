using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class StardustBand : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("12% increased minion damage \nGrants immunity to the [c/FF4E00:On Fire!], [c/A84DFD:Distorted], and [c/9362B3:Obstructed] debuffs");
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
		player.GetDamage(DamageClass.Summon) += 0.12f;
		player.buffImmune[BuffID.OnFire] = true;
		player.buffImmune[BuffID.Obstructed] = true;
		player.buffImmune[BuffID.VortexDebuff] = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HallowedBand>())
			.AddIngredient(ItemID.FragmentStardust, 6)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
