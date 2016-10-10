using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Projectiles.Npc
{
	public class VulcHammer : ModProjectile
	{
		int fCount = 0;
        bool inHand = true;
        float hx = -150; //6
        float hy = 50f; //108
        float ox = -150f;
        float oy = 50f;
        int recSize = 20;
        int hTime = 100;
        int timer = 0;
        int Soundt = 100;

		public override void SetDefaults()
		{
			projectile.name = "Vulcoron's Hammer";
			projectile.width = 88;
			projectile.height = 68;
			projectile.timeLeft = 10;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 2;
            projectile.frame = 1;

        }
		
		public override void AI()
		{
            if (Soundt > 0)
            {
                Soundt--;
            }
            else
            {
                Soundt = 100;
            }
            projectile.timeLeft += 5;
                
            if (Main.npc[(int)projectile.ai[0]].name != "Vulcoron")
            {
                projectile.Kill();
            }


            if (inHand)
            {
                if (Soundt % 10 == 0)
                {
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 19);
                }

                if (timer == 0)
                {
                    if (projectile.frame == 0)
                    {
                        timer = hTime;
                    }
                    else
                    {
                        inHand = false;
                        timer = 0;
                    }
                }
                
                if (timer > 0)
                {
                    timer--;
                }

                projectile.frame = 1;
                projectile.position.X = Main.npc[(int)projectile.ai[0]].position.X + ox;
                projectile.position.Y = Main.npc[(int)projectile.ai[0]].position.Y + oy;
                projectile.rotation += 0.1f;
                fCount = 0;
            }
            else
            {
                if (Soundt % 5 == 0)
                {

                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 19);
                }


                projectile.rotation += 0.3f;
			    fCount++;	
			    Dust.NewDust(projectile.position, projectile.width, projectile.height, 158);
			
			    float nx = Main.npc[(int)projectile.ai[0]].position.X + (Main.npc[(int)projectile.ai[0]].width/2);
			    float ny = Main.npc[(int)projectile.ai[0]].position.Y + (Main.npc[(int)projectile.ai[0]].height/2);
			    float px = projectile.position.X + (projectile.width/2);
			    float py = projectile.position.Y + (projectile.height/2);
                float w = projectile.width/4;
                float h = projectile.height/4;

                if (fCount > 100)
			    {

			        if (nx + hx < px ) 
					    {
                            if (Math.Abs(nx + hx - px) > 300)
                            {
                                projectile.velocity.X = -50;
                            }
                            else
                            {
                                projectile.velocity.X = -10;
                            }
					    }
					
					    if (nx + hx > px) 
					    {
                            if (Math.Abs(nx + hx - px) > 300)
                            {
                                projectile.velocity.X = 50;
                            }
                            else
                            {
                                projectile.velocity.X = 10;
                            }
                        }
					
					    if (ny + hy < py) 
					    {
                            if (Math.Abs(ny + hy - py) > 300)
                            {
                                projectile.velocity.Y = -50;
                            }
                            else
                            {
                                projectile.velocity.Y = -10;
                            }
                        }
					
					    if (ny + hy > py) 
					    {
                            if (Math.Abs(ny + hy - py) > 300)
                            {
                                projectile.velocity.Y = 50;
                            }
                            else
                            {
                                projectile.velocity.Y = 10;
                            }
                        }

                        Rectangle nh = new Rectangle((int)(px), (int)(py), (int)(projectile.width), (int)(projectile.height));
                        Rectangle n = new Rectangle((int)(nx + hx - recSize), (int)(ny + hy - recSize), recSize * 2, recSize * 2);
					    if (nh.Intersects(n))
					    {
                        ox = projectile.position.X - Main.npc[(int)projectile.ai[0]].position.X;
                        oy = projectile.position.Y - Main.npc[(int)projectile.ai[0]].position.Y;
                        inHand = true;
                            for (int i = 0; i < 50; i++)
                            {
                                Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
                            }
                            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
                    }
			    }
                else
                {
                    if (projectile.frame == 1)
                    {
                        projectile.velocity.X = (float)((Main.player[(int)projectile.ai[1]].position.X - px) / 25);
                        projectile.velocity.Y = (float)((Main.player[(int)projectile.ai[1]].position.Y - py) / 25);
                    }
                }

                projectile.frame = 0;
            }
		}


		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			for (int i = 0; i < 50; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
            }
        }
	}
}