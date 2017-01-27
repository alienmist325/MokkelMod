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

        Helper h = new Helper();

        bool ft = true;

        //test
        public byte NPI = 0;//nearest player index
        public float curDist = 0;
        public float minDist = 0;
        public Vector2 curVect;
        public Vector2 minVect;//vector between npi and npc

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

        public override void AI()
        {

            //teleport broodmother to player on spawn
            npc.position = !ft ? npc.position : Main.LocalPlayer.position - new Vector2(0, 200);
            h.pMth = !ft ? h.pMth : Vector2.Zero;
            ft = false;
            try
            {
                FindNPI();
            }
            catch(Exception e)
            {
                ErrorLogger.Log("FINDNPI: " + e.ToString());
            }
            ErrorLogger.Log("It works?");
            //print values
            //Main.NewText("Dist away: " + h.away(Main.player[Main.myPlayer].position, npc.position).ToString());
            Main.NewText("Rotation: " + h.d(h.rot).ToString());

            try
            {
                Projectile.NewProjectile(h.pMth, Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0f);
            }
            catch(Exception e)
            {
                ErrorLogger.Log("Projectile Error: " + e.ToString());
            }

        }

        public void FindNPI()
		{
            ErrorLogger.Log("1");
            try
            {
                for (byte i = 0; i < 255; i++)
                {
                    if (Main.player[i].active)
                    {
                        ErrorLogger.Log("2");
                        curVect = Main.player[i].Center - npc.Center;
                        curDist = curVect.Length(); //distance between npc and player

                        if (curDist < minDist || minDist == 0)
                        {
                            NPI = i;
                            minDist = curDist;
                            minVect = curVect;
                        }
                        ErrorLogger.Log("3");
                    }
                    else
                    {
                        ErrorLogger.Log("4");
                        i = 255; //break from cycle because all proceeding positions will be null.
                    }
                }
                ErrorLogger.Log("5");
            }
            catch (Exception e)
            {
                ErrorLogger.Log("FINDNPI: " + e.ToString());
            }
            ErrorLogger.Log("6");
        }
		
		
		
		public void FindQuadrant(ref int q, ref float rad,Vector2 v)
		{
			// q is quadrant, r is rotation, v is vector
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
			a += (h.rot - h.r(90));
			h.rv.Y = (float)Math.Sin(a)*d;
			h.rv.X = (float)Math.Cos(a)*d;
			newPos = npc.Center + h.rv; 
		}
		
		public void AssignDrawVars()
		{
			h.screenPos = npc.position - Main.screenPosition;
			h.screenPos -= new Vector2(0,120);
			h.screenPos += new Vector2(wi/2,he/2);
			h.brdMthr = mod.GetTexture("Content/Sprites/NPCs/General/BroodMother");
			h.drawnRegion = new Rectangle(0,h.frameNum*he,wi,he);
			FindQuadrant(ref h.qnt,ref h.rot,h.minVect);
            h.se = SpriteEffects.None;
        }
		
		public void pos(Vector2 np)
		{
			npc.position = np - new Vector2(wi/2,he/2);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            if (!Main.gamePaused)
            {
                //Counter();
                AssignDrawVars();
                //CanShoot();
                // to make it 0 - 360, rather than 0 - 180 then 0 - -180 (find quadrant)
                //RestrictRot();
                FindRotPnt(-120, 34, ref h.pMth); //find mouth
                FindRotPnt(-51, 34, ref h.pEgg);
                //AdjustRot();
            }

            try
            {
                h.log("Deg: " + h.d(h.rot).ToString(), "Rad " + h.rot.ToString());
                spriteBatch.Draw(h.brdMthr, h.screenPos, h.drawnRegion, drawColor, h.rot, new Vector2(wi / 2, he / 2), 1f, h.se, 0);
            }
            catch(Exception e)
            {
                ErrorLogger.Log(e.ToString());
            }
			
			return false;
		}
	}	
}