using System;
using MokkelMod.Content.Unreleased.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Buffs
{
    public class Inscribed : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffName[Type] = "Inscribed";
            Main.buffTip[Type] = "";
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            PlayerX p = (PlayerX)player.GetModPlayer(mod, "PlayerX");
            p.inscribed = true;
        }
    }
}
