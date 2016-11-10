using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	public class AntlionEgg : ModNPC
	{	
		int frameNum = 1;
		bool toRight = true;
		int timer = 0;
		
		public override void SetDefaults()
		{
			npc.name = "Antlion Egg";
			npc.width = 36;
			npc.height = 42;
			npc.lifeMax = 200;
			npc.noGravity = false;
			npc.damage = 0;
			npc.defense = 20;
			npc.noTileCollide = false;
			npc.soundHit = 2;
			npc.soundKilled = 5;
			npc.timeLeft = NPC.activeTime * 30;
			npc.value = 100f;
			npc.knockBackResist = 0f;
			Main.npcFrameCount[npc.type] = 3;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frame = new Rectangle(0,frameHeight*(frameNum-1),36,frameHeight);
		}
		
		public int gtp(int X)
		{
			//get tile position
			//is it x or y, bool X tells you
			if(X == 0)
			{
				return (int)(npc.Center.X/16);
			}
			else
			{
				return (int)(npc.Center.Y/16);
			}
			
		}
		public override void AI()
		{
			if (Main.tile[gtp(0),gtp(1)].active())
			{
				npc.timeLeft = 0;
			}
			timer++;
			if(timer % 200 == 0)
			{
				for (int i = 0; i < 10; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 32);
				}
				frameNum++;
			}
			if(timer == 600)
			{
				for (int i = 0; i < 50; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 32);
				}
				NPC.NewNPC((int)npc.Center.X,(int)npc.Center.Y,NPCID.FlyingAntlion);
				npc.life = 0;
			}
			npc.rotation += (3.14f/90) * (toRight ? 1 : -1);
			if (npc.rotation > 3.14f/64)
			{
				toRight = false;
			}
			if (npc.rotation < -3.14f/64)
			{
				toRight = true;
			}
		}	
	}
}