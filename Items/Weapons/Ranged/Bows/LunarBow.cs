using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows;

public class LunarBow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Lunar Bow");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, doesn't require ammo]\nGrants the [c/13A2DA:Shattered Moon's Grace] buff when shooting, reducing fall speed\nUsing <right> while under max HP grants the [c/5EDF85:Shattered Moon's Blessing] buff, which has the following effects:\n - Heals the player rapidly for 2 seconds, but disables the use of items\n - Grants [c/9CE53B:Shattered Moon's Rejuvenation] after 2 seconds, healing 100 HP over 10 seconds\n[c/5EDF85:Shattered Moon's Blessing] has a cooldown of [c/CA4646:50 seconds] once the effect ends");
	}

	public override void SetDefaults()
	{
		Item.damage = 240;
		Item.width = 27;
		Item.height = 69;
		Item.useTime = 9;
		Item.useAnimation = 9;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 15, 60, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 50f;
		Item.shoot = ModContent.ProjectileType<LunarBolt>();
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		if (player.altFunctionUse == 2)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsCurse>()) && player.statLife < player.statLifeMax2)
			{
				player.AddBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsBlessing>(), 140, true);
			}
			player.AddBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsGrace>(), 10, true);
		}
		else
		{
			player.AddBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsGrace>(), 10, true);
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
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.LifeFruit, 5);
		val.AddIngredient(ItemID.LifeCrystal, 5);
		val.AddIngredient(ItemID.FragmentVortex, 14);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
