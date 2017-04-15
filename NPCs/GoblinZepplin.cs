using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.NPCs
{
    public class GoblinZepplin : ModNPC
    {
		private bool SpawnedCannon = false;
        public override void SetDefaults()
        {
            npc.noTileCollide = true;
            npc.name = "Goblin Zepplin";
            npc.width = 216;
            npc.height = 140;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 100;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath22;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void AI()
        {
            npc.dontTakeDamage = true;
            if (!SpawnedCannon)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<GoblinCannon>(), ai0: npc.whoAmI);
                npc.ai[3] = 1;
				SpawnedCannon = true;
			}
			if (npc.ai[3] == 0)
			{
			npc.life = 0;	
			}
            int NPCPosY = (int)(npc.position.Y + npc.height);
            int PlayerPos = (int)Main.player[npc.target].position.Y;
            int BlockDistanceFromPly = 13;

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
            if (Math.Abs(num1932) >= 225f && (Math.Abs(npc.velocity.X) < 5f || Math.Sign(npc.velocity.X) != npc.direction))
            {
                npc.velocity.X = npc.velocity.X + (float)npc.direction * 0.07f;
            }
            npc.rotation = npc.velocity.X * 0.025f;
            npc.spriteDirection = Math.Sign(npc.velocity.X);

        }


        public override void FindFrame(int frameHeight)
        {

            //Simple code for basic "next frame" animation
            npc.frameCounter += 0.2F; //Frame "Speed"
            npc.frameCounter %= Main.npcFrameCount[npc.type]; //Frame number
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;

        }
    }
}
