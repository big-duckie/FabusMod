using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class DemonsFury : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Demon's Fury");
		// Tooltip.SetDefault("[c/B6FF00:Autoswings]\nFires a beam of particles that ignores immunity frames, pierces 5 times, and regenerates 1 Mana with every hit\nInflicts [c/7B2D2F:Advanced Blood Loss] for 14 seconds when hit with the blade, dealing damage over time\n<right> uses 40 Mana to bring up spikes from the ground, dealing damage with a 2% chance of granting a [c/EC566E:Souleater] stack\nHas an 8% chance to fire soul-absorbing shards, granting a stack of [c/EC566E:Souleater] when hit\nHaving 6 stacks of [c/EC566E:Souleater] restores 75 HP and Mana");
	}

	public override void SetDefaults()
	{
		Item.damage = 80;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 63;
		Item.height = 76;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 23, 25, 0);
		Item.rare = ItemRarityID.Pink;
		Item.mana = 0;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.AdvancedBloodLoss>(), 840, false);
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RyuuDust3>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2 && player.velocity.Y == 0f && player.statMana >= 40)
		{
			Item.damage = 50;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.shootSpeed = 0f;
			Item.mana = 40;
			Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.DemonProjRMB>();
			Item.UseSound = SoundID.Item88;
		}
		else
		{
			Item.damage = 80;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.shootSpeed = 10f;
			Item.mana = 0;
			if (Utils.NextFloat(Main.rand) < 0.08f)
			{
				Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.DemonProjTwo>();
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.DemonWave>();
			}
			Item.UseSound = SoundID.Item1;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:CarbonSword")
			.AddRecipeGroup("FabusMod:AdamantiteBar", 10)
			.AddIngredient(ItemID.SoulofNight, 8)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4)
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}
