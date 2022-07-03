using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class HellfireBand : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hellfire Band");
		Tooltip.SetDefault("4% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!] debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 36;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.accessory = true;
		Item.defense = 4;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Generic) += 0.04f;
		player.buffImmune[24] = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<IronBand>());
		val.AddIngredient(ItemID.HellstoneBar, 3);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
