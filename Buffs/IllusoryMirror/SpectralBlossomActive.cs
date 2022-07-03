using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.IllusoryMirror;

public class SpectralBlossomActive : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spectral Blossom Active");
        Description.SetDefault("Stand near it to receive buffs!");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }
}
