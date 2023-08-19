using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
public class ValkyrieWings : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Heroes always fly!");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 38;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.rare = ItemRarityID.Pink;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.wingTimeMax = 180;
	}

	public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
	{
		ascentWhenFalling = 0.75f;
		ascentWhenRising = 0.2f;
		maxCanAscendMultiplier = 1f;
		maxAscentMultiplier = 2f;
		constantAscend = 0.11f;
	}

	public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
	{
		speed = 6f;
		acceleration *= 1f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.HallowedBar, 10)
			.AddIngredient(ItemID.SoulofFlight, 20)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
