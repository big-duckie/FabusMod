using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class GoldenFury : ModItem
{
	public override void SetStaticDefaults()
	{
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
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default(Color), 1f);
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
			Item.damage = 70;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.shootSpeed = 0f;
			Item.mana = 40;
			Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.GoldenFuryProjRMB>();
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
				Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.GoldenFuryProjTwo>();
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<Projectiles.Shimada.GoldenFuryWave>();
			}
			Item.UseSound = SoundID.Item1;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<DemonsFury>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 10)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4)
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}
