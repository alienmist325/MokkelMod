using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{
	public class Sandstorm : ModProjectile
	{
		int travelTime = 100;
		bool oscillate = false;
		float osX;
		int dir = 1;
		float px;
		
		public override void SetDefaults()
		{
			projectile.name = "Sandstorm";
			projectile.width = 52;
			projectile.height = 54;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.damage = 100;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.extraUpdates = 1;
			projectile.aiStyle = -1;
			Main.projFrames[projectile.type] = 6;

		}
		
		public void decideFrame()
		{
			projectile.frameCounter++;
			if(projectile.frameCounter == 3)
			{
				projectile.frame = projectile.frame == 5 ? 0 : projectile.frame; 
				projectile.frame += 1;
				projectile.frameCounter -= 10;
			}
		}
		
		public override void AI()
		{
			Dust.NewDust(projectile.position + new Vector2(projectile.width/4,-projectile.height/4),projectile.width/2 ,projectile.height/2,233);
			decideFrame();
			travelTime -= travelTime > 0 ? 1 : 0;
			if (travelTime == 0)
			{
				projectile.velocity.X -= (projectile.velocity.X > 0 ? 1 : -1) * (projectile.velocity.X == 0 ? 0 : 0.1f);
				projectile.velocity.Y -= (projectile.velocity.Y > 0 ? 1 : -1) * (projectile.velocity.Y == 0 ? 0 : 0.1f);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for(int i = 0; i < 100; i++)
			{
				Dust.NewDust(projectile.position,projectile.width/2,projectile.height/2,233);
			}
		}
	}
}