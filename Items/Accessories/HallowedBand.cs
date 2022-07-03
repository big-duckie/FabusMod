using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class HallowedBand : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("8% increased all damage \nGrants immunity to the [c/FF4E00:On Fire!] debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Pink;
		Item.accessory = true;
		Item.defense = 6;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Generic) += 0.08f;
		player.buffImmune[24] = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<HellfireBand>());
		recipe.AddIngredient(ItemID.HallowedBar, 3);
		recipe.AddIngredient(ItemID.Ruby, 2);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
