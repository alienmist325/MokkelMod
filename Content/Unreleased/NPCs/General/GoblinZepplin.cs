﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.NPCs.General
{
    public class GoblinZepplin : ModNPC
    {
        public override void SetDefaults()
        {
            npc.noTileCollide = true;
            npc.name = "GoblinZepplin";
            npc.width = 216;
            npc.height = 140;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 100;
            npc.lifeMax = 1000;
            npc.soundHit = 4;
            npc.soundKilled = 22;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void AI()
        {

            int NPCPosY = (int)(npc.position.Y + npc.height);
            int PlayerPos = (int)Main.player[npc.target].position.Y;
            int BlockDistanceFromPly = 20;

            npc.TargetClosest(true);

            if (NPCPosY > PlayerPos - BlockDistanceFromPly * 16)
            {
                //Go up
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, -4f, 0.10f);
            }
            else if(NPCPosY < PlayerPos + BlockDistanceFromPly * 16)
            {
                //Go down
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 4f, 0.10f);
            }

        //Ported from flying duchman ai
            float num1932 = Main.player[npc.target].Center.X - npc.Center.X;
            if (Math.Abs(num1932) >= 300f && (Math.Abs(npc.velocity.X) < 6f || Math.Sign(npc.velocity.X) != npc.direction))
            {
                npc.velocity.X = npc.velocity.X + (float)npc.direction * 0.06f;
            }
            npc.rotation = npc.velocity.X * 0.025f;
            npc.spriteDirection = Math.Sign(npc.velocity.X);

        }


        public override void FindFrame(int frameHeight)
        {

            //Simple code for basic "next frame" animation
            npc.frameCounter += 0.1F; //Frame "Speed"
            npc.frameCounter %= Main.npcFrameCount[npc.type]; //Frame number
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;

        }
    }
}
