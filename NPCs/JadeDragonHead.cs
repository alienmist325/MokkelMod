using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;

namespace MokkelMod.NPCs
{

    public class JadeDragonHead : ModNPC
    {
		private void WatchPlayer(Player player)
		{
			Vector2 look = npc.Center - player.Center;
			LookAt(look);
		}
		private void LookAt(Vector2 look)
		{
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f)
			{
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f)
			{
				angle += (float)Math.PI;
			}
			if (look.X < 0f)
			{
				angle += (float)Math.PI;
			}
			npc.rotation = angle - 90f;
		}
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
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            npc.value = 10000f;
            npc.scale = 1f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
			Main.npcFrameCount[npc.type] = 3;
        }
		public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }
		  public override bool PreAI()
        {
            if (Main.netMode != 1)
            {
               
                if (npc.ai[0] == 0)
                {
                   
                    npc.realLife = npc.whoAmI;
                 
                    int latestNPC = npc.whoAmI;
 
                 
                    int randomWormLength = Main.rand.Next(6, 7);
                    for (int i = 0; i < randomWormLength; ++i)
                    {
                       
                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("JadeDragonBody"), npc.whoAmI, 0, latestNPC);
                        Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                        Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                    }
                    
                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("JadeDragonTail"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
 
                    npc.ai[0] = 1;
                    npc.netUpdate = true;
                }
            }
			return true;
		}
        public override void AI()
        {
			npc.TargetClosest(true);
            
            Player player = Main.player[npc.target];
			WatchPlayer(player);
			npc.velocity += Vector2.Normalize((player.Center - npc.Center) * 2f);
			 npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -5, 5);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -5, 5);
        }
	}
}
