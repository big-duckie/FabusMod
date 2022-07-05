using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic;

public class IllusoryMirror : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nShoots 5 instant beams in quick succession\nUsing <right> uses 50 Mana to summon a [c/E6A6CF:Blossom] at the player's position for 20 seconds:\n - Being around the [c/E6A6CF:Blossom] buffs HP regeneration, increases attack speed, and increases magic damage by 15%\n - [c/E6A6CF:Blossom] has a cooldown of [c/CA4646:50 seconds] once it disappears\nBest used on 'High' video quality!");
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.ShadowbeamStaff);
		Item.damage = 175;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 7;
		Item.width = 29;
		Item.height = 21;
		Item.useTime = 5;
		Item.useAnimation = 25;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.value = Item.sellPrice(0, 11, 60, 0);
		Item.autoReuse = true;
		Item.shootSpeed = 7f;
		Item.expert = true;
		Item.reuseDelay = 20;
		Item.UseSound = SoundID.Item72;
		Item.shoot = ModContent.ProjectileType<Projectiles.IllusoryMirror.IllusoryMirrorProj>();
	}

	public override Vector2? HoldoutOffset()
	{
        return new Vector2(4f, 0f);
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomInactive>()) && !player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomActive>()))
			{
				Item.useTime = 25;
				Item.useAnimation = 25;
				Item.shootSpeed = 0f;
				Item.mana = 50;
				player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomActive>(), 1200, true);
				Item.shoot = ModContent.ProjectileType<Projectiles.IllusoryMirror.IllusoryMirrorRMB>();
				Item.UseSound = SoundID.Item76;
			}
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.StrongerTogether>()))
		{
			Item.useTime = 4;
			Item.useAnimation = 20;
			Item.shootSpeed = 7f;
			Item.mana = 7;
			Item.shoot = ModContent.ProjectileType<Projectiles.IllusoryMirror.IllusoryMirrorProj>();
			Item.UseSound = SoundID.Item72;
		}
		else
		{
			Item.useAnimation = 25;
			Item.useTime = 5;
			Item.shootSpeed = 7f;
			Item.mana = 7;
			Item.shoot = ModContent.ProjectileType<Projectiles.IllusoryMirror.IllusoryMirrorProj>();
			Item.UseSound = SoundID.Item72;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.LifeFruit, 5)
			.AddIngredient(ItemID.LifeCrystal, 5)
			.AddIngredient(ItemID.FragmentNebula, 14)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
