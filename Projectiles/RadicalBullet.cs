using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Projectiles
{
	public class RadicalBullet : ModProjectile
	{
		bool radicalise = false;
		
		public override void SetDefaults()
		{
			projectile.name = "Radical Bullet";
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 10000;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.damage = 1500;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.extraUpdates = 1;
			
		}
		

		
		public override void AI()
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Radical"));
			projectile.frameCounter++;
			projectile.rotation += 0.3f;
			
			if (projectile.frameCounter == 70)
			{
				this.radicalise = Main.rand.NextDouble() > 0.5;
			}
			if (this.radicalise)
			{
				projectile.hostile = true;
				projectile.friendly = false;
				projectile.damage = 250;
				
				if (Main.myPlayer == projectile.owner)
				{
					if (Main.player[projectile.owner].position.X < projectile.position.X) 
					{
						if (Main.player[projectile.owner].position.X < projectile.position.X - 5 )
						{	
							projectile.velocity.X = -5;
						} 
						else
						{
							projectile.position.X = Main.player[projectile.owner].position.X; 
						}
					}
					
					if (Main.player[projectile.owner].position.X > projectile.position.X) 
					{
						if (Main.player[projectile.owner].position.X > projectile.position.X + 5 )
						{
							projectile.velocity.X = 5;	
						} 
						else
						{
							projectile.position.X = Main.player[projectile.owner].position.X; 
						}
					}
					
					if (Main.player[projectile.owner].position.Y < projectile.position.Y) 
					{
						if (Main.player[projectile.owner].position.Y < projectile.position.Y - 5 )					
						{
							projectile.velocity.Y = -5;
						} 
						else
						{
							projectile.position.Y = Main.player[projectile.owner].position.Y; 
						}
					}
					
					if (Main.player[projectile.owner].position.Y > projectile.position.Y) 
					{
						if (Main.player[projectile.owner].position.Y > projectile.position.Y + 5 )
						{
							projectile.velocity.Y = 5;
						} 
						else
						{
							projectile.position.Y = Main.player[projectile.owner].position.Y; 
						}
					}
					
					Rectangle plyrRec = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
					Rectangle prjRec = new Rectangle((int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, Main.player[projectile.owner].width, Main.player[projectile.owner].height);
					if (plyrRec.Intersects(prjRec))
					{
						projectile.Kill();
					}
				}
			}
			if (this.radicalise == false && projectile.frameCounter > 71)
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			int a = 0;
			while (a < 100)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RadicalDust"));
				a++;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int b = 0;
			while (b < 50)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RadicalDust"));
				b++;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{	
			projectile.velocity.X = oldVelocity.X/8;
			projectile.velocity.Y = oldVelocity.Y/8;
			return false;
		}
	

	}
}