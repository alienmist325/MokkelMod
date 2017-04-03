using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	public class BroodMother : ModNPC
	{	
        //ensure broodmother disappears when killed
        //get vulc summon working
        //make it such that you can control brd from chat
        //remove changes to World.cs

		//test out rotpnt method
		int he = 276;
		int wi = 260;
		float rad;
		float deg;
		Vector2 dist;
        Helper h = new Helper();
        bool ft = true;
        Vector2 toP;
        Vector2 nv;

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
            //allow for toggling of side
            h.RHS *= npc.ai[1] == 1 ? -1 : 1;
            npc.ai[1] = 0;
            //teleport broodmother to player on spawn
            npc.position = !ft ? npc.position : Main.LocalPlayer.position - new Vector2(0, 200);
            npc.ai[0] = ft ? -1 : npc.ai[0];
            ft = false;

            if(npc.ai[0] != -1)
            {
                h.phase = (int)npc.ai[0];
                h.pTimer[h.phase] = 0;
                npc.ai[0] = -1;
            }

            h.FindNPI(npc);
            h.Timer();
            //Projectile.NewProjectile(h.pMth, Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0f);
            h.testPos(h.pEgg);
            Phase();
        }

        public void Phase()
        {
            switch(h.phase)
            {
                case 0:
                    Shoot();
                    //move to one side of the player
                    ShootMove();
                    break;
                case 1:
                    if (h.preSwoop)
                    {
                        PreSwoop();
                    }
                    else
                    {
                        Swoop();
                    }
                    break;
                case 2:
                    Lay();
                    break;
            }
        }

        public void pos(Vector2 np)
        {
            npc.position = np - new Vector2(npc.width / 2, npc.height / 2);
        }

        public void Shoot()
        {
            //pCenter + 30.pVel + rnd(rand).
            //rand flucs.
            Vector2 toP = Main.player[h.NPI].Center + new Vector2(30 * Main.player[h.NPI].velocity.X, 0) + new Vector2(Main.rand.Next(-h.rand, h.rand), Main.rand.Next(-h.rand, h.rand)) - npc.Center;

            if (h.canShoot(toP))
            {
                h.turbo = false;
                toP.Normalize();
                toP *= 10;
                if (h.pTimer[0] % 30 == 0)
                {
                    h.Fluc(ref h.rand, 100, 20, 1);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 65);
                    //presumably slight change in placement when flipped
                    if (h.se == SpriteEffects.FlipVertically)
                    {
                        h.pMth += new Vector2(16, 16);
                    }
                    Projectile.NewProjectile(h.pMth, toP, mod.ProjectileType("SandSpit"), 1, 0f);
                }
            }
            else
            {
                //it only speeds up if it isn't in a position where it can shoot you
                h.turbo = true;
            }

        }

        public void ShootMove()
        {
            Vector2 target;
            h.oldTarg = Main.player[h.NPI].Center;  
            target = h.oldTarg + new Vector2(400 * h.RHS, -200) + h.Turbo(Main.player[h.NPI].velocity);
            MoveTo(target, h.vel);    
        }

        public bool MoveTo(Vector2 target, float speed) //bool tells you when movement is finished
        {
            h.testPos(target);
            nv = target - npc.Center;
            if (nv.Length() < Math.Sqrt(2 * Math.Pow(h.vel, 2)) + 0.1f)
            {
                //npc.velocity = Vector2.Zero;
                nv /= 2;
                
            }
            else
            {
                nv.Normalize();
                nv *= speed;
            }
            //ErrorLogger.Log(nv.ToString());
            npc.velocity = nv;
            if (nv.Length() < 0.01f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PreSwoop()
        {
            if (h.swpStrt)
            {

                h.swpStrt = false;
                h.swpNPC = npc.Center;
                h.swpOrig = h.swpNPC + new Vector2(0, 100);
                h.swpPlyr = Main.player[h.NPI].Center;
                h.swpPnt = h.swpPlyr - npc.Center + new Vector2(100 * h.RHS, -50);
            }
            if (MoveTo(new Vector2(h.swpNPC.X, h.swoopFormula(h.swpNPC.X - h.swpOrig.X) + h.swpOrig.Y), 8))
            {
                h.preSwoop = false;
            }
        }

        public void Swoop()
        {
            h.testPos(h.swpPnt);
            h.testPos(h.swpOrig);
            npc.velocity.X = h.accelerate();
            pos(new Vector2(npc.Center.X, h.swoopFormula(npc.Center.X - h.swpOrig.X) + h.swpOrig.Y));
            if(Math.Abs(npc.Center.X - h.swpPlyr.X + (-100*h.RHS)) < Math.Abs(npc.velocity.X) * 2)
            {
                h.passedPlayer = true;
            }
            if (npc.Center.Y - h.swpNPC.Y < 5 && h.pTimer[1] > 35)
            {
                h.swpStrt = true;
                h.preSwoop = true;
                h.passedPlayer = false;
                h.phase--;
                h.RHS *= -1;
                h.pTimer[1] = 0;
            }
        }

        public void Lay()
        {
            if (h.pTimer[2] == 500)
            {
                Vector2 tP = h.gtp(h.pEgg);
                if (Main.tile[(int)tP.X, (int)tP.Y].active())
                {

                    NPC.NewNPC((int)h.pEgg.X, (int)h.pEgg.Y, mod.NPCType("AntlionEgg"),0,1,npc.whoAmI);
                }
                else
                {
                    NPC.NewNPC((int)h.pEgg.X, (int)h.pEgg.Y, mod.NPCType("AntlionEgg"),0,0,0);
                }
            }
        }

        //draw
        public void FindQuadrant(ref int q, ref float rad,Vector2 v)
		{
			// q is quadrant, r is rotation, v is vector
			rad = h.swpStrt ? (float)Math.Atan2(v.Y,v.X) : rad; 
            h.real = rad + 3.14f;
            h.rec("FQ", ref h.real, Main.player[h.NPI].velocity, npc.Center);
            q = h.inq(h.real,0,90) ? 1 : q;
			q = h.inq(h.real,90,180) ? 2 : q;
            q = h.inq(h.real,180,270) ? 3 : q;
			q = h.inq(h.real,270,360) ? 4 : q;
		}
		
		public void FindRotPnt(int x,int y,ref Vector2 newPos)
		{
			Vector2 v = new Vector2(x,y);
            Vector2 rv;
            float d = v.Length();
			float a = (float)Math.Atan2(v.Y,v.X);
            a += h.rot;//(h.rot - h.r(90));
			rv.Y = (float)Math.Sin(a)*d;
			rv.X = (float)Math.Cos(a)*d;
			newPos = npc.Center + rv + new Vector2(0,-22); 
		}
		
		public void AssignDrawVars()
		{
			h.screenPos = npc.position - Main.screenPosition;
			h.screenPos -= new Vector2(0,120);
			h.screenPos += new Vector2(wi/2,he/2);
			h.brdMthr = mod.GetTexture("Content/Sprites/NPCs/General/BroodMothera");
			h.drawnRegion = new Rectangle(0,h.frameNum*he,wi,he);
			FindQuadrant(ref h.qnt,ref h.rot,h.minVect);
            if (h.qnt == 1 || h.qnt == 4)
            {
                h.se = SpriteEffects.None;
            }
            else
            {
                h.se = SpriteEffects.FlipVertically;
            }
            if(!h.swpStrt)
            {
                h.se = h.se | SpriteEffects.FlipHorizontally;
            }
            
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            if (!Main.gamePaused)
            {
                //Counter();
                AssignDrawVars();
                // to make it 0 - 360, rather than 0 - 180 then 0 - -180 (find quadrant)
                h.RestrictRot();
                h.real -= h.r(180);
                h.real += h.real < 0 ? h.r(360) : 0;
                h.real -= 3.14f;
                h.rot = h.swpStrt ? h.real : h.rot;
                if (h.qnt == 1 || h.qnt == 4)
                {
                    FindRotPnt(-112, 50, ref h.pMth); //find mouth //-120 ,34
                    FindRotPnt(-51, 34, ref h.pEgg);
                }
                else
                {
                    FindRotPnt(-112, -50, ref h.pMth); //find mouth //-120 ,34
                    FindRotPnt(-51, -34, ref h.pEgg);
                }
            }
            spriteBatch.Draw(h.brdMthr, h.screenPos, h.drawnRegion, drawColor, h.real, new Vector2(wi / 2, he / 2), 1f, h.se, 0);
			return false;
		}

    }	
}