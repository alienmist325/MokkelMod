using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Buffs
{
    public class JadeFire : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffName[Type] = "Jade Fire";
            Main.buffTip[Type] = "You are burning with green flames";
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
			{
                npc.lifeRegen = 0;
			}
            npc.lifeRegen -= 12;
        }
    }
}
