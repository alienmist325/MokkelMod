using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Projectiles.Npc
{
	public class SandSpit : ModProjectile
	{
		
		public override void SetDefaults()
		{
			projectile.name = "Sand Spit";
			projectile.width = 41;
			projectile.height = 15;
			projectile.timeLeft = 100;
			projectile.penetrate = 2;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.hostile = true;
			projectile.scale = 1.5f;
			projectile.light = 2f;
			projectile.tileCollide = true;
			projectile.damage = 0;
			Main.projFrames[projectile.type] = 8;
		}
		
		public override void AI()
		{
			Dust.NewDust(projectile.Center, 10, 10, 32);
			projectile.timeLeft += 10;
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y,projectile.velocity.X);
			projectile.frameCounter++;
			if (projectile.frameCounter == 1)
			{
				projectile.frame = 0;
			}
			if (projectile.frameCounter == 2)
			{
				projectile.frame = 1;
			}
			if (projectile.frameCounter == 3)
			{
				projectile.frame = 2;
			}
			if (projectile.frameCounter == 4)
			{
				projectile.frame = 3;
			}
			if (projectile.frameCounter == 5)
			{
				projectile.frame = 4;
			}
			if (projectile.frameCounter == 6)
			{
				projectile.frame = 5;
			}
			if (projectile.frameCounter == 7)
			{
				projectile.frame = 6;
			}
			if (projectile.frameCounter == 8)
			{
				projectile.frame = 7;
			}
			if (projectile.frameCounter == 9)
			{
				projectile.frameCounter = 0;
			}
			
		}
		
	}
}