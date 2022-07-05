using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows;

public class LunarRainBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Lunar Rain-Bow");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, doesn't require ammo]\nGrants the [c/E6A6CF:Spectral Moon's Grace] buff when shooting, reducing fall speed and nullifying knockback \nUsing <right> while under max HP grants the [c/82E8E8:Spectral Moonlight] buff, which has the following effects:\n - Heals the player rapidly for 2 seconds and grants immunity, but disables the use of items\n - Grants [c/6DE5D8:Spectral Moon's Rejuvenation] after 2 seconds, healing 200 HP over 10 seconds and increasing ranged crit rate by 60\n[c/82E8E8:Spectral Moonlight] has a cooldown of [c/BF5E3B:50 seconds] once the effect ends");
	}

	public override void SetDefaults()
	{
		Item.damage = 320;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 27;
		Item.height = 69;
		Item.useTime = 7;
		Item.useAnimation = 7;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(2, 70, 0, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 50f;
		Item.shoot = ModContent.ProjectileType<SpectralMoonBolt>();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (player.altFunctionUse == 2)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsCurse>()) && player.statLife < player.statLifeMax2)
			{
				player.AddBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonlight>(), 140, true);
			}
			player.AddBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsGrace>(), 10, true);
		}
		else
		{
			player.AddBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsGrace>(), 10, true);
		}
		return true;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<LunarBow>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 14)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
