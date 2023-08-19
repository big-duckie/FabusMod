using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FabusMod
{
    internal class FabuRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Fox Ears",
                ModContent.ItemType<Items.Vanity.FoxEars.FoxEars>(),
                ModContent.ItemType<Items.Vanity.FoxEars.PinkFoxEars>(),
                ModContent.ItemType<Items.Vanity.FoxEars.BlueFoxEars>()
            );
            RecipeGroup.RegisterGroup("FabusMod:FoxEars", group);

            RecipeGroup group2 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Punk's Pulse",
                ModContent.ItemType<Items.Weapons.Ranged.PulsePistols.PunksPulse>(),
                ModContent.ItemType<Items.Weapons.Ranged.PulsePistols.PunksPulseUltraviolet>()
            );
            RecipeGroup.RegisterGroup("FabusMod:PunksPulse", group2);

            RecipeGroup group3 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Pulse Sprayer",
                ModContent.ItemType<Items.Weapons.Ranged.PulsePistols.PulseSprayer>(),
                ModContent.ItemType<Items.Weapons.Ranged.PulsePistols.PulseSprayerCadet>()
            );
            RecipeGroup.RegisterGroup("FabusMod:PulseSprayer", group3);

            RecipeGroup group4 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Rainbow Demon",
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemon>(),
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemonClaymore>(),
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemonRanged>(),
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemonThrowing>(),
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemonMagic>(),
                ModContent.ItemType<Items.Weapons.RainbowDemon.TheRainbowDemonShredder>()
            );
            RecipeGroup.RegisterGroup("FabusMod:TheRainbowDemon", group4);

            RecipeGroup group5 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} The Stinger",
                ModContent.ItemType<Items.Weapons.Ranged.LightGuns.TheStinger>(),
                ModContent.ItemType<Items.Weapons.Ranged.LightGuns.TheStingerBlackCat>()
            );
            RecipeGroup.RegisterGroup("FabusMod:TheStinger", group5);

            RecipeGroup group6 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Shivering Shotgun",
                ModContent.ItemType<Items.Weapons.Ranged.Shotguns.HellshiverGun>(),
                ModContent.ItemType<Items.Weapons.Ranged.Shotguns.HellshiverGunHellfire>()
            );
            RecipeGroup.RegisterGroup("FabusMod:HellshiverGun", group6);

            RecipeGroup group7 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Hellraiser",
                ModContent.ItemType<Items.Weapons.Ranged.Shotguns.HellkinShotgun>(),
                ModContent.ItemType<Items.Weapons.Ranged.Shotguns.HellkinShotgunDracula>()
            );
            RecipeGroup.RegisterGroup("FabusMod:HellkinShotgun", group7);

            RecipeGroup group8 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Carbon Shuriken",
                ModContent.ItemType<Items.Weapons.Thrown.Shuriken.CarbonShuriken>(),
                ModContent.ItemType<Items.Weapons.Thrown.Shuriken.CarbonShurikenNihon>()
            );
            RecipeGroup.RegisterGroup("FabusMod:CarbonShuriken", group8);

            RecipeGroup group9 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Solitude",
                ModContent.ItemType<Items.Weapons.Ranged.Peacekeeper.Peacegunner>(),
                ModContent.ItemType<Items.Weapons.Ranged.Peacekeeper.PeacegunnerAmerican>()
            );
            RecipeGroup.RegisterGroup("FabusMod:Peacegunner", group9);

            RecipeGroup group10 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Silencer",
                ModContent.ItemType<Items.Weapons.Ranged.Peacekeeper.Peaceforcer>(),
                ModContent.ItemType<Items.Weapons.Ranged.Peacekeeper.PeaceforcerVanHelsing>()
            );
            RecipeGroup.RegisterGroup("FabusMod:Peaceforcer", group10);

            RecipeGroup group11 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Carbon Sword",
                ModContent.ItemType<Items.Weapons.Melee.Swords.ShimadaSwords.CarbonSword>(),
                ModContent.ItemType<Items.Weapons.Melee.Swords.ShimadaSwords.CarbonSwordNihon>()
            );
            RecipeGroup.RegisterGroup("FabusMod:CarbonSword", group11);

            RecipeGroup group12 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Light's Bane",
                ItemID.LightsBane,
                ItemID.BloodButcherer
            );
            RecipeGroup.RegisterGroup("FabusMod:LightsBane", group12);

            RecipeGroup group13 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Carbon Dagger",
                ModContent.ItemType<Items.Weapons.Melee.Shortswords.CarbonDagger>(),
                ModContent.ItemType<Items.Weapons.Melee.Shortswords.CarbonDaggerNihon>()
            );
            RecipeGroup.RegisterGroup("FabusMod:CarbonDagger", group13);

            RecipeGroup group14 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Sorcerer's Hellstaff",
                ModContent.ItemType<Items.Weapons.Magic.Staffs.SorcerersHellstaff>(),
                ModContent.ItemType<Items.Weapons.Magic.Staffs.SorcerersHellstaffWhite>()
            );
            RecipeGroup.RegisterGroup("FabusMod:SorcerousHellstaff", group14);

            RecipeGroup group15 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Fox Pistol",
                ModContent.ItemType<Items.Weapons.Ranged.FoxPistols.FoxPistol>(),
                ModContent.ItemType<Items.Weapons.Ranged.FoxPistols.FoxPistolBlue>()
            );
            RecipeGroup.RegisterGroup("FabusMod:FoxPistol", group15);

            RecipeGroup group16 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Demonite Bar",
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            );
            RecipeGroup.RegisterGroup("FabusMod:DemoniteBar", group16);

            /*RecipeGroup group17 = new(() => Language.GetTextValue("LegacyMisc.37") + " Elemental Water Staff", new int[4] {
                Find<ModItem>("ElementalWaterStaff").Type,
                Find<ModItem>("ElementalWaterStaffRed").Type,
                Find<ModItem>("ElementalWaterStaffGreen").Type,
                Find<ModItem>("ElementalWaterStaffYellow").Type
            });
            RecipeGroup.RegisterGroup("FabusMod:ElementalWaterStaff", group17);*/

            RecipeGroup group18 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Gold Bar",
                ItemID.GoldBar,
                ItemID.PlatinumBar
            );
            RecipeGroup.RegisterGroup("FabusMod:GoldBar", group18);

            RecipeGroup group19 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Adamantite Bar",
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            );
            RecipeGroup.RegisterGroup("FabusMod:AdamantiteBar", group19);

            RecipeGroup group20 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Protective Fusion",
                ModContent.ItemType<Items.Weapons.Ranged.FusionDrivers.ProtectionFuser>(),
                ModContent.ItemType<Items.Weapons.Ranged.FusionDrivers.ProtectionFuserCarbonFiber>()
            );
            RecipeGroup.RegisterGroup("FabusMod:ProtectionFuser", group20);

            RecipeGroup group21 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Mythril Bar",
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            );
            RecipeGroup.RegisterGroup("FabusMod:MythrilBar", group21);

            RecipeGroup group22 = new(() => $"{Language.GetTextValue("LegacyMisc.37")} Verano",
                ModContent.ItemType<Items.Weapons.Ranged.MachinePistols.Verano>(),
                ModContent.ItemType<Items.Weapons.Ranged.MachinePistols.VeranoRime>()
            );
            RecipeGroup.RegisterGroup("FabusMod:Verano", group22);
        }

        public override void AddRecipes()
        {
            Recipe val = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.FoxEars>());
            val.AddRecipeGroup("FabusMod:FoxEars");
            val.AddIngredient(ItemID.OrangeDye);
            val.AddTile(TileID.DyeVat);
            val.Register();

            Recipe val2 = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.PinkFoxEars>());
            val2.AddRecipeGroup("FabusMod:FoxEars");
            val2.AddIngredient(ItemID.PinkDye);
            val2.AddTile(TileID.DyeVat);
            val2.Register();

            Recipe val3 = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.BlueFoxEars>());
            val3.AddRecipeGroup("FabusMod:FoxEars");
            val3.AddIngredient(ItemID.SkyBlueDye);
            val3.AddTile(TileID.DyeVat);
            val3.Register();
        }
    }
}
