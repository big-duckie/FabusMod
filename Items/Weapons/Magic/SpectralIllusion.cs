using FabusMod.Projectiles.IllusoryMirror;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic;

public class SpectralIllusion : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Spectral Illusion");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nShoots 6 instant beams in quick succession\nUsing <right> uses 50 Mana to summon a [c/82E8E8:Spectral Blossom] at the player's position for 20 seconds:\n - Being around the [c/82E8E8:Spectral Blossom] buffs HP regeneration, increases attack speed, and increases magic damage by 18%\n - Being around the [c/82E8E8:Spectral Blossom] also increases invincibility time after being hit, and has a cooldown of [c/BF5E3B:50 seconds] once it disappears\nBest used on 'High' video quality!");
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.ShadowbeamStaff);
		Item.damage = 325;
		Item.noMelee = true;
		Item.mana = 6;
		Item.width = 33;
		Item.height = 25;
        Item.useTime = 4;
		Item.useAnimation = 24;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.value = Item.sellPrice(2, 50, 0, 0);
		Item.autoReuse = true;
		Item.shootSpeed = 7f;
		Item.expert = true;
		Item.reuseDelay = 20;
		Item.UseSound = SoundID.Item72;
		Item.shoot = ModContent.ProjectileType<SpectralIllusionProj>();
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
			if (!player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomInactive>()) && !player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomActive>()))
			{
				Item.useTime = 25;
				Item.useAnimation = 25;
				Item.shootSpeed = 0f;
				Item.mana = 50;
				player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomActive>(), 1200, true);
				Item.shoot = ModContent.ProjectileType<SpectralIllusionRMB>();
				Item.UseSound = SoundID.Item76;
				Item.reuseDelay = 20;
			}
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBloom>()))
		{
			Item.useTime = 3;
			Item.useAnimation = 16;
			Item.shootSpeed = 7f;
			Item.mana = 6;
			Item.shoot = ModContent.ProjectileType<SpectralIllusionProj>();
			Item.UseSound = SoundID.Item72;
			Item.reuseDelay = 18;
		}
		else
		{
			Item.useAnimation = 24;
			Item.useTime = 4;
			Item.shootSpeed = 7f;
			Item.mana = 6;
			Item.shoot = ModContent.ProjectileType<SpectralIllusionProj>();
			Item.UseSound = SoundID.Item72;
			Item.reuseDelay = 20;
		}
		return this.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<IllusoryMirror>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 14);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
