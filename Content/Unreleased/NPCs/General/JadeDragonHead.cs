using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;

namespace MokkelMod.Content.Sprites.NPCs.General
{

    public class JadeDragonHead : ModNPC
    {
        public override void SetDefaults()
        {
            npc.displayName = "Jade Dragon";
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.name = "JadeDragonHead";
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = -1;
            npc.netAlways = true;
            npc.damage = 80;
            npc.defense = 10;
            npc.lifeMax = 4000;
            npc.soundHit = 7;
            npc.soundKilled = 8;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            npc.value = 10000f;
            npc.scale = 1f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
        }

        public override void AI()
        {
            
            
        }
    }
}
