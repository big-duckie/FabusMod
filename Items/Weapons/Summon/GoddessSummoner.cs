using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Summon;

public class GoddessSummoner : ModItem
{
	public override void SetDefaults()
	{
		Item.damage = 120;
		Item.DamageType = DamageClass.Summon;
		Item.mana = 18;
		Item.width = 58;
		Item.height = 62;
		Item.useTime = 36;
		Item.useAnimation = 36;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.noMelee = true;
		Item.knockBack = 3f;
		Item.value = Item.buyPrice(0, 9, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item44;
		Item.shoot = ModContent.ProjectileType<Projectiles.Minions.GoddessMinion>();
		Item.shootSpeed = 1f;
		Item.buffType = ModContent.BuffType<Buffs.GoddessMinionBuff>();
		Item.buffTime = 3600;
	}

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Goddess' Summoning Staff");
		// Tooltip.SetDefault("Summons a golden servant to fight for you");
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		return player.altFunctionUse != 2;
	}

	public override bool? UseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			player.MinionNPCTargetAim(false);
		}
		return base.UseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 16)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
