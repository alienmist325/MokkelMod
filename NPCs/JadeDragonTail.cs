using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MokkelMod.NPCs
{

    public class JadeDragonTail : ModNPC
    {
        public static int NPCID;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Dragon");
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = true;
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = -1;
            npc.netAlways = true;
            npc.damage = 40;
            npc.defense = 20;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            npc.value = 10000f;
            npc.scale = 1f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.dontCountMe = true;
        }


        public override void AI()
        {

            
        }


    }

    

}
