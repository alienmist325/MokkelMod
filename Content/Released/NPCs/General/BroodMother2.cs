using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	
	/**
	I was attempting to check whether the rotation was correct (minus rot correction) and whether the mouth calc was correct.
	However, for some reason, BRDMTHR was disappearing and despawning immediately. Hence, I now need to put a try catch round
	sprite batch draw to find and fix the error.
	**/
	
	public class BroodMother : ModNPC
	{	
		//test out rotpnt method
		int he = 276;
		int wi = 260;
		float rad;
		float deg;
		Vector2 dist;
		public override void SetDefaults()
		{
			npc.name = "Brood Mother";
			npc.width = 260; //hitbox
			npc.height = 64; //hitbox
			npc.lifeMax = 4000;
			npc.noGravity = true;
			npc.damage = 20;
			npc.defense = 15;
			npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.boss = true;
			npc.value = 100000f;
			npc.knockBackResist = 0f;
		}
		
		public void FindNPI()
		{
			Helper h = new Helper();
			for(byte i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					h.minDist = 0;
					h.curVect = Main.player[i].Center - npc.Center;
					h.curDist = h.curVect.Length(); //distance between npc and player
					
					if (h.curDist < h.minDist||h.minDist == 0)
					{
						h.NPI = i;
						h.minDist = h.curDist;
						h.minVect = h.curVect;
					}
				}
				else
				{
					i = 255; //break from cycle because all proceeding positions will be null.
				}
			}
		}
		
		public override void AI()
		{
			Helper h = new Helper();
			dist = Main.player[h.NPI].Center - npc.Center;
			rad = (float)Math.Atan2(dist.X,dist.Y);
			deg = (float)((180 * rad)/Math.PI);
			Main.NewText(deg.ToString());
			Projectile.NewProjectile(h.pMth,Vector2.Zero,mod.ProjectileType("Fireball"),0,0f);
		}
		
		public void FindQuadrant(ref int q, ref float rad,Vector2 v)
		{
			// q is quadrant, r is rotation, v is vector
			Helper h = new Helper();
			rad = (float)Math.Atan2(v.Y,v.X);
			float r = rad + 3.14f; 
			q = h.inq(r,0,90) ? 1 : q;
			q = h.inq(r,90,180) ? 2 : q;
			q = h.inq(r,180,270) ? 3 : q;
			q = h.inq(r,270,360) ? 4 : q;
		}
		
		public void FindRotPnt(int x,int y,ref Vector2 newPos)
		{
			Helper h = new Helper();
			Vector2 v = new Vector2(x,y);
			float d = (float)v.Length();
			float a = (float)Math.Atan2(v.Y,v.X);
			Main.NewText("hi");
			a += (h.rot - h.r(90));
			
			h.rv.Y = (float)Math.Sin(a)*d;
			h.rv.X = (float)Math.Cos(a)*d;
			Main.NewText("hi");
			newPos = npc.Center + h.rv; 
			Main.NewText("hsi");
		}
		
		public void AssignDrawVars()
		{
			Main.NewText("hi");
			Helper h = new Helper();
			h.screenPos = npc.position - Main.screenPosition;
			h.screenPos -= new Vector2(0,120);
			h.screenPos += new Vector2(wi/2,he/2);
			h.brdMthr = mod.GetTexture("Content/Sprites/NPCs/General/BroodMother");
			h.drawnRegion = new Rectangle(0,h.frameNum*he,wi,he);
			FindQuadrant(ref h.qnt,ref h.rot,h.minVect);
			
			//Main.NewText(qnt.ToString());
		}
		
		public void pos(Vector2 np)
		{
			npc.position = np - new Vector2(wi/2,he/2);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Helper h = new Helper();
			if (!Main.gamePaused)
			{
				//Counter();
				AssignDrawVars();
				//CanShoot();
				// to make it 0 - 360, rather than 0 - 180 then 0 - -180 (find quadrant)
				//RestrictRot();
				FindRotPnt(-120,34,ref h.pMth); //find mouth
				FindRotPnt(-51,34,ref h.pEgg);
				//AdjustRot();
				
			}
			
			spriteBatch.Draw(h.brdMthr,h.screenPos,h.drawnRegion,drawColor,h.rot,new Vector2(wi/2,he/2),1f,h.se,0);
			
			return false;
		}
	}	
}