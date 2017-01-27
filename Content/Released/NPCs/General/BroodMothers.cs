using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	public class BroodMothers : ModNPC
	{	
		//general
		int w = 260;
		int h = 276;
		byte phase = 0;
		int qnt; //1 top left, going clockwise	
		//FindNPI
		byte NPI;//nearest player index
		float curDist = 0;
		float minDist = 0;
		Vector2 curVect;
		Vector2 minVect;
		
		//Select frame
		int[] timer = new int[4];
		byte frameNum;
		
		//Draw sprite
		float rot = 0;
		Vector2 screenPos;
		Texture2D brdMthr;
		Rectangle drawnRegion;
		SpriteEffects se; // left = none
		
		//locating rotated locations
		float d; //distance
		float a; //angle
		Vector2 v; //vector
		Vector2 rv; //vector after sprite is rotated.
		
		Vector2 pMth;//mouth position
		Vector2 eggHatch;
		
		//Move to point
		Vector2 movement;
		
		Vector2 target;
		Vector2 startPos;
		int tqnt;
		float trot;
		
		int oldPhase;
		bool onLeft = true;
		
		bool canShoot = true;
		bool up = true;
		float vel = 5;
		Vector2 toP = Vector2.Zero;
		Vector2 toPlayer;
		
		public override void SetDefaults()
		{
			npc.name = "Brood Mother";
			npc.width = 260;
			npc.height = 64;//276 - 128 - 92
			npc.lifeMax = 4000;
			npc.noGravity = true;
			npc.damage = 20;
			npc.defense = 15;
			npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.timeLeft = NPC.activeTime * 30;
			npc.boss = true;
			npc.value = 100000f;
			npc.knockBackResist = 0f;
		}
		
		public override void AI()
		{
			
			FindNPI();
			Main.PlaySound(2,(int)Main.player[NPI].position.X, (int)Main.player[NPI].position.Y,32);//Projectile.NewProjectile(pMth,Vector2.Zero,mod.ProjectileType("Fireball"),0,0f);
			
			if (phase == 0)
			{
				//shoot sand spits
				FindVector(5f,Main.player[NPI].Center + new Vector2(-400*(onLeft ? 1 : -1),-300),true);
				Shoot();
				
			}
			if (phase == 1)
			{
				Swoop();
				if(timer[3] % 5 == 0)
				{
					Main.PlaySound(17, (int)npc.position.X, (int)npc.position.Y, 0);
				}
			}
			if (phase == 2)
			{
				
				//egg laying
				FindVector(vel,target + new Vector2(0,-50 + (10 * (up ? 1 : -1))),true);
				if(npc.velocity == Vector2.Zero)
				{
					up = !up;
					vel = 0.2f;
				}
				npc.damage = 0;
				npc.defense = 5;
			}
		}
		
		public void Swoop()
		{
			Main.NewText((npc.Center - target).Length().ToString());
			Projectile.NewProjectile(pMth,Vector2.Zero,mod.ProjectileType("Fireball"),0,0f);
			if((npc.Center - target).Length() > 100)
			{
				
				//still swooping
				npc.position.Y = MathHelper.Lerp(npc.position.Y,target.Y,0.05f);
			}
			else
			{
				if(npc.position == target)
				{
					npc.position = target;
					npc.velocity = Vector2.Zero;
					target = Main.player[NPI].Center;
					phase = 2;
				}
				else
				{
					toPlayer = target - npc.position;
					toPlayer.Normalize();
					npc.velocity = 8f * toPlayer;
				}
				
			}

			FindQuadrant(ref tqnt,ref trot, target - npc.Center);
			if(tqnt == 2 || tqnt == 3)
			{
				npc.velocity.X = 8f;
			}
			else
			{
				npc.velocity.X = -8f;
			}
		}
		
		public void Shoot()
		{
			toP = Main.player[NPI].Center + new Vector2(60*Main.player[NPI].velocity.X,0) + new Vector2(Main.rand.Next(-100,100),Main.rand.Next(-100,100));
			if(timer[1] % 30 == 0 && canShoot)
			{
				Main.PlaySound(2,(int)npc.position.X, (int)npc.position.Y,65);
				for(int i = 0; i < 1;i++)
				{
					Projectile.NewProjectile(pMth,FindVector(10f,toP,false),mod.ProjectileType("SandSpit"),1,0f);
				}
				
			}
		}
		
		public void FindNPI()
		{
			for(byte i = 0; i < 254; i++)
			{
				if (Main.player[i].active)
				{
					minDist = 0;
					curVect = Main.player[i].Center - npc.Center;
					curDist = curVect.Length(); //distance between npc and player
					
					if (curDist < minDist||minDist == 0)
					{
						NPI = i;
						minDist = curDist;
						minVect = curVect;
					}
				}
				else
				{
					i = 254; //break from cycle because all proceeding positions will be null.
				}
			}
		}
		
		public void Counter()
		{
			timer[3]++;
			if(timer[3] == 100)
			{
				timer[3] = 0;
			}
			//frame control
			timer[0]++;
			if(timer[0] == 5)
			{
				frameNum = 1;
			}
			if(timer[0] == 10)
			{
				frameNum = 0;
				timer[0] = 0;
			}
			//sand spit
			if(phase == 0)
			{
				timer[1]++;
				if(timer[1] == 600)
				{
					target = Main.player[NPI].Center;
					onLeft = !onLeft;
					phase = 1;
					timer[1] = 0;
				}
			}
			if(phase == 2)
			{
				timer[2]++;
				if(timer[2] == 100)
				{
					Main.PlaySound(2,(int)npc.position.X, (int)npc.position.Y,5);
					NPC.NewNPC((int)eggHatch.X,(int)eggHatch.Y,mod.NPCType("AntlionEgg"));
				}
				if(timer[2] == 200)
				{
					phase = 0;
					timer[2] = 0;
				}
			}
			
		}
		
		public void AssignDrawVars()
		{
			screenPos = npc.position - Main.screenPosition;
			screenPos -= new Vector2(0,120);
			screenPos += new Vector2(w/2,h/2);
			brdMthr = mod.GetTexture("Content/Sprites/NPCs/General/BroodMother");
			drawnRegion = new Rectangle(0,frameNum*h,w,h);
			FindQuadrant(ref qnt,ref rot,minVect);
			//Main.NewText(qnt.ToString());
		}
		
		public void FindQuadrant(ref int q, ref float r,Vector2 v)
		{
			// q is quadrant, r is rotation, v is vector
			r = (float)Math.Atan2(v.Y,v.X);
			r += 3.14f; 
			q = tIneq(r,0,90) ? 1 : q;
			q = tIneq(r,90,180) ? 2 : q;
			q = tIneq(r,180,270) ? 3 : q;
			q = tIneq(r,270,360) ? 4 : q;
		}
		
		public float dtr(int a)
		{
			//degrees to radians
			return (float)MathHelper.ToRadians(a);
		}
		
		public bool tIneq(float n,int s,int g)
		{
			//test inequality g is greater, s is smaller
			return (dtr(s) < n && n < dtr(g));
		}
		
		public void RestrictRot()
		{
			//Main.NewText(MathHelper.ToDegrees(rot).ToString());
			//restrict rotation
			//left
			if (qnt == 1 && rot > dtr(10))
			{
				rot = dtr(10);
				se = SpriteEffects.None;
			}
			if (qnt == 4 && rot < dtr(350))
			{
				rot = dtr(350);
				se = SpriteEffects.None;
			}
			//right
			if (qnt == 2 && rot < dtr(170))
			{
				rot = dtr(170);
				se = SpriteEffects.FlipHorizontally;
			}
			if (qnt == 3 && rot > dtr(190))
			{
				rot = dtr(190);
				se = SpriteEffects.FlipHorizontally;
			}

		}
		
		public void FindRotPnt(int x,int y,ref Vector2 newPos)
		{
			v = new Vector2(x,y);
			d = (float)v.Length();
			a = (float)Math.Atan2(v.Y,v.X);
			
			if(qnt == 1 || qnt == 4)
			{
				a += rot;
			}
			else if(qnt == 2 || qnt == 3)
			{
				a *= -1;
				a += rot;
			}
			
			rv.Y = (float)Math.Sin(a)*d;
			rv.X = (float)Math.Cos(a)*d;
			newPos = npc.Center + rv; 
		}
		
		public void AdjustRot()
		{
			if(qnt == 1||qnt == 4)
			{
				rot += 3.14f;
			}
			rot += 3.14f; // put it back to normal
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			if (!Main.gamePaused)
			{
				Counter();
				AssignDrawVars();
				CanShoot();
				// to make it 0 - 360, rather than 0 - 180 then 0 - -180 (find quadrant)
				RestrictRot();
				FindRotPnt(-120,34,ref pMth); //find mouth
				FindRotPnt(-51,34,ref eggHatch);
				AdjustRot();
				
			}
			
			spriteBatch.Draw(brdMthr,screenPos,drawnRegion,drawColor,rot,new Vector2(w/2,h/2),1f,se,0);
			
			return true;
		}
		
		public void CanShoot()
		{
			if (tIneq(rot,240,300) || tIneq(rot,60,120))
			{
				canShoot = false;
			}
			else
			{
				canShoot = true;
			}
			
			//if(toP.X > 0 && se = S)
		}
		
		public Vector2 FindVector(float speed, Vector2 center, bool move)
		{
			movement = center - npc.Center;
			
			if(move)
			{
				if (movement.Length() < 5)
				{
					npc.position = center - (npc.Center - npc.position);
					npc.velocity = Vector2.Zero;
				}
				else
				{
					movement.Normalize();
					movement *= speed;
					npc.velocity = movement;
				}
			}
			else
			{
				movement.Normalize();
				movement *= speed;
			}
			
			return movement;
		}
	}
}