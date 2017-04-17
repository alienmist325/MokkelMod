using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MokkelMod.Content.Unreleased.Players;

namespace MokkelMod.Buffs
{
    public class Enraged : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffName[Type] = "Enraged";
            Main.buffTip[Type] = "";
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            PlayerX p = (PlayerX)player.GetModPlayer(mod, "PlayerX");
            p.enraged = true;
        }
    }
}
