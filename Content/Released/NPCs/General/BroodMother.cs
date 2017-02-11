using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	//1 - <30
    //2 - >150
    //3 - <240
    //4 - >300
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
        Vector2 toP;

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
            ft = false;
            h.FindNPI(npc);
            h.Timer();
            //Projectile.NewProjectile(h.pMth, Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0f);
            Projectile.NewProjectile(h.pEgg, Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0f);
            if (h.phase == 1)
            {
                Shoot();
                //move to one side of the player
                ShootMove();
            }
            Hover();
        }

        public void ShootMove()
        {
            Vector2 target;
            
            target = Main.player[h.NPI].Center + new Vector2(400 * h.LHS.ToInt(), -200);
            MoveTo(target,5);
        }

        public void MoveTo(Vector2 target, int speed)
        {
            npc.velocity = target - npc.Center;
            Main.NewText(npc.velocity.ToString());
            if(npc.velocity.Length() < 7.1f)
            {
                npc.velocity = Vector2.Zero;
            }
            else
            {
                npc.velocity.Normalize();
                npc.velocity *= speed;
            }
        }

        public void Hover()
        {
            Vector2 hov;
            h.Fluc(ref h.hoverPos, 25, -25, 0);
            hov = new Vector2(0, h.hoverPos);
            hov.Normalize();
            hov *= 2;
            npc.velocity += hov;
        }

        public void Shoot()
        {
            Vector2 toP = Main.player[h.NPI].Center + new Vector2(60 * Main.player[h.NPI].velocity.X, 0) + new Vector2(Main.rand.Next(-h.rand, h.rand), Main.rand.Next(-h.rand, h.rand)) - npc.Center;

            if (h.canShoot(toP))
            {
                toP.Normalize();
                toP *= 10;
                if (h.timer[1] % 30 == 0)
                {
                    h.Fluc(ref h.rand, 100, 20, 1);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 65);
                    if (h.se == SpriteEffects.FlipVertically)
                    {
                        h.pMth += new Vector2(16, 16);
                    }
                    Projectile.NewProjectile(h.pMth, toP, mod.ProjectileType("SandSpit"), 1, 0f);
                }
            }
            
        }

        /**public void tempShoot()
        {
            toP = Main.player[h.NPI].Center - npc.Center;
            toP.Normalize();
            toP *= 10;
            if (h.timer[1] % 30 == 0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 65);
                try
                {
                    if (h.se == SpriteEffects.FlipVertically)
                    {
                        h.pMth += new Vector2(16, 16);
                    }
                    Projectile.NewProjectile(h.pMth, toP, mod.ProjectileType("SandSpit"), 1, 0f);
                }
                catch(Exception e)
                {
                    ErrorLogger.Log(e.ToString());
                }
            }
        }**/

        public void FindQuadrant(ref int q, ref float rad,Vector2 v)
		{
			// q is quadrant, r is rotation, v is vector
			rad = (float)Math.Atan2(v.Y,v.X); 
            h.real = rad + 3.14f;
            h.rec("FQ", ref h.real);
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
                h.RestrictRot();
                h.real -= h.r(180);
                h.real += h.real < 0 ? h.r(360) : 0;
                h.real -= 3.14f;
                h.rot = h.real;
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