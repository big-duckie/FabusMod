using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod;

public class FabuPlayer : ModPlayer
{
	public class WeaponAbilityPlayerEffects : ModPlayer
	{
		public bool activated;

		public bool activated2;

		public bool activated3;

		public bool activated4;

		public bool activated5;

		public bool activated6;

		public bool activated7;

		public bool activated8;

		public bool activated9;

		public bool activated10;

		public bool activated11;

		public bool activated12;

		public bool activated13;

		public bool activated14;

		public bool activated15;

		public bool activated16;

		public bool activated17;

		public bool activated18;

		public bool activated19;

		public bool activated20;

		public bool activated21;

		public bool activated22;

		public bool activated23;

		public bool activated24;

		public bool activated25;

		public bool activated26;

		public bool activated27;

		public bool activated28;

		public bool activated29;

		public bool activated30;

		public bool activated31;

		public bool activated32;

		public bool activated33;

		public bool activated34;

		public bool activated35;

		public bool activated36;

		public bool soundPlayed;

		public override void PreUpdate()
		{
			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsBlessing>()))
			{
				activated = true;
			}
			else if (activated)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsCurse>(), 3000, true);
				activated = false;
			}

			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsCurse>()))
			{
				activated2 = true;
			}
			else if (activated2)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Shattered Moon's Blessing ready!");
				activated2 = false;
			}

			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsBlessing>()) && !soundPlayed)
			{
				if (Main.rand.NextBool(5))
				{
					SoundEngine.PlaySound(SoundID.Item13);
				}
				soundPlayed = true;
			}

			if (!Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsBlessing>()))
			{
				soundPlayed = false;
			}

			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsBlessing>()))
			{
				activated3 = true;
			}
			else if (activated3)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.LunarBow.ShatteredMoonsRejuvenation>(), 600, true);
				activated3 = false;
			}

			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonlight>()))
			{
				activated4 = true;
			}
			else if (activated4)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsCurse>(), 3000, true);
				activated4 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsCurse>()))
			{
				activated5 = true;
			}
			else if (activated5)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Spectral Moonlight ready!");
				activated5 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonlight>()) && !soundPlayed)
			{
				if (Main.rand.NextBool(5))
				{
					SoundEngine.PlaySound(SoundID.Item13);
				}
				soundPlayed = true;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonlight>()))
			{
				soundPlayed = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonlight>()))
			{
				activated6 = true;
			}
			else if (activated6)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.LunarBow.SpectralMoonsRejuvenation>(), 600, true);
				activated6 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomActive>()))
			{
				activated7 = true;
			}
			else if (activated7)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomInactive>(), 3000, true);
				activated7 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.BlossomInactive>()))
			{
				activated8 = true;
			}
			else if (activated8)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Blossom ready!");
				activated8 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomActive>()))
			{
				activated9 = true;
			}
			else if (activated9)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomInactive>(), 3000, true);
				activated9 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.IllusoryMirror.SpectralBlossomInactive>()))
			{
				activated10 = true;
			}
			else if (activated10)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Spectral Blossom ready!");
				activated10 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.SouleaterOne>()))
			{
				activated11 = true;
			}
			else if (activated11)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(190, 60, 60), "Absorbed a soul!");
				activated11 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.SouleaterTwo>()))
			{
				activated12 = true;
			}
			else if (activated12)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(190, 60, 60), "Absorbed two souls!");
				activated12 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.SouleaterThree>()))
			{
				activated13 = true;
			}
			else if (activated13)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(190, 60, 60), "Absorbed three souls!");
				activated13 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.SouleaterFour>()))
			{
				activated14 = true;
			}
			else if (activated14)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(190, 60, 60), "Absorbed four souls!");
				activated14 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.SouleaterFive>()))
			{
				activated15 = true;
			}
			else if (activated15)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(92, 229, 237), "Absorbed five souls!");
				activated15 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.EnrichmentOne>()))
			{
				activated16 = true;
			}
			else if (activated16)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(210, 210, 90), "Absorbed a soul!");
				activated16 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.EnrichmentTwo>()))
			{
				activated17 = true;
			}
			else if (activated17)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(210, 210, 90), "Absorbed two souls!");
				activated17 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.EnrichmentThree>()))
			{
				activated18 = true;
			}
			else if (activated18)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(210, 210, 90), "Absorbed three souls!");
				activated18 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.EnrichmentFour>()))
			{
				activated19 = true;
			}
			else if (activated19)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(210, 210, 90), "Absorbed four souls!");
				activated19 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.EnrichmentFive>()))
			{
				activated20 = true;
			}
			else if (activated20)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(92, 229, 237), "Absorbed five souls!");
				activated20 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamOne>()))
			{
				activated21 = true;
			}
			else if (activated21)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 82, 220), "Sapped a dream!");
				activated21 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamTwo>()))
			{
				activated22 = true;
			}
			else if (activated22)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 82, 220), "Sapped two dreams!");
				activated22 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamThree>()))
			{
				activated23 = true;
			}
			else if (activated23)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 82, 220), "Sapped three dreams!");
				activated23 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFour>()))
			{
				activated24 = true;
			}
			else if (activated24)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 82, 220), "Sapped four dreams!");
				activated24 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFive>()))
			{
				activated25 = true;
			}
			else if (activated25)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 82, 220), "Sapped five dreams!");
				activated25 = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.SpectralRage>()))
			{
				activated26 = true;
			}
			else if (activated26)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 61, 0), "Enraged!");
				activated26 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharging>()))
			{
				activated27 = true;
			}
			else if (activated27)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>(), 480, true);
				activated27 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>()))
			{
				activated28 = true;
			}
			else if (activated28)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.Shotgun.HyperchargeCooldown>(), 2400, true);
				activated28 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.HyperchargeCooldown>()))
			{
				activated29 = true;
			}
			else if (activated29)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Ready to Hypercharge!");
				activated29 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharging>()) && !soundPlayed)
			{
				if (Main.rand.NextBool(5))
				{
					SoundEngine.PlaySound(SoundID.Item13);
				}
				soundPlayed = true;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharging>()))
			{
				soundPlayed = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>()))
			{
				activated30 = true;
			}
			else if (activated30)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 61, 0), "Hypercharged!");
				activated30 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>()))
			{
				activated31 = true;
			}
			else if (activated31)
			{
				CombatText.NewText(Player.Hitbox, new Color(138, 138, 138), "No longer Hypercharged!");
				activated31 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharging>()))
			{
				activated32 = true;
			}
			else if (activated32)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>(), 480, true);
				activated32 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>()))
			{
				activated33 = true;
			}
			else if (activated33)
			{
				Player.AddBuff(ModContent.BuffType<Buffs.Shotgun.UltrachargeCooldown>(), 2400, true);
				activated33 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.UltrachargeCooldown>()))
			{
				activated34 = true;
			}
			else if (activated34)
			{
				SoundEngine.PlaySound(SoundID.Unlock);
				CombatText.NewText(Player.Hitbox, new Color(0, 255, 0), "Ready to Ultracharge!");
				activated34 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharging>()) && !soundPlayed)
			{
				if (Main.rand.NextBool(5))
				{
					SoundEngine.PlaySound(SoundID.Item13);
				}
				soundPlayed = true;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharging>()))
			{
				soundPlayed = false;
			}
			if (!Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>()))
			{
				activated35 = true;
			}
			else if (activated35)
			{
				SoundEngine.PlaySound(SoundID.Item4);
				CombatText.NewText(Player.Hitbox, new Color(255, 61, 0), "Ultracharged!");
				activated35 = false;
			}
			if (Player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>()))
			{
				activated36 = true;
			}
			else if (activated36)
			{
				CombatText.NewText(Player.Hitbox, new Color(138, 138, 138), "No longer Ultracharged!");
				activated36 = false;
			}
		}
	}

	private const int saveVersion = 0;

	public bool foxPet;

	public bool pinkFoxPet;

	public bool kregPet;

	public bool fabuLightPet;

	public bool fabu;

	public bool goddessMinion;

	public override void ResetEffects()
	{
		foxPet = false;
		pinkFoxPet = false;
		kregPet = false;
		fabuLightPet = false;
		fabu = false;
		goddessMinion = false;
	}

    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
    {
		return new[]
		{
			new Item(ModContent.ItemType<Items.Items.CraftingIngredients.BrokenBand>())
		};
    }
}
