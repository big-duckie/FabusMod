using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.FusionNeedlers;

public class FusedXmas : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\n[c/FF0000:Watch your mana!]");
	}

	public override void SetDefaults()
	{
		Item.damage = 140;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 3;
		Item.width = 80;
		Item.height = 52;
		Item.useTime = 4;
		Item.useAnimation = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 8, 40, 0);
		Item.rare = ItemRarityID.Red;
		Item.UseSound = SoundID.Item39;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PineNeedleFriendly;
		Item.shootSpeed = 18f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<FusionNeedler>())
			.AddIngredient(ItemID.FragmentVortex, 12)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
