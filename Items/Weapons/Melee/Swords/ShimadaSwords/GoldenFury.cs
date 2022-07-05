using FabusMod.Projectiles.Shimada;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class GoldenFury : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Fury");
		Tooltip.SetDefault("[c/B6FF00:Autoswings]\nFires a beam of particles that ignores immunity frames, pierces 6 times, and regenerates 1 Mana with every hit\nInflicts [c/7B2D2F:Advanced Blood Loss] for 14 seconds when hit with the blade, dealing damage over time\n<right> uses 40 Mana to bring up [c/C4AB37:Midas]-inducing spikes from the ground, dealing damage with a 2% chance of granting an [c/D2D25A:Enrichment] stack\nHas a 10% chance to fire soul-absorbing shards, granting a stack of [c/D2D25A:Enrichment] when hit\nHaving 6 stacks of [c/D2D25A:Enrichment] restores 75 HP and Mana");
	}

	public override void SetDefaults()
	{
		Item.damage = 100;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 63;
		Item.height = 76;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 23, 25, 0);
		Item.rare = ItemRarityID.Pink;
		Item.mana = 0;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.AdvancedBloodLoss>(), 840, false);
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default(Color), 1f);
			Main.dust[num1].scale = 1f;
			Main.dust[num1].velocity.Y = 0f;
			Main.dust[num1].velocity.X = 0.5f;
			Main.dust[num1].noGravity = true;
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
			Item.damage = 70;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.shootSpeed = 0f;
			Item.mana = 40;
			Item.shoot = ModContent.ProjectileType<GoldenFuryProjRMB>();
			Item.UseSound = SoundID.Item88;
		}
		else
		{
			Item.damage = 100;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.shootSpeed = 10f;
			Item.mana = 0;
			if (Utils.NextFloat(Main.rand) < 0.1f)
			{
				Item.shoot = ModContent.ProjectileType<GoldenFuryProjTwo>();
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<GoldenFuryWave>();
			}
			Item.UseSound = SoundID.Item1;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<DemonsFury>());
		recipe.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 10);
		recipe.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4);
		recipe.AddTile(TileID.DemonAltar);
		recipe.Register();
	}
}
