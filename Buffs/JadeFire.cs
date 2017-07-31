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
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
			DisplayName.SetDefault("Jade Fire");
			Description.SetDefault("You are burning with green flames");
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
