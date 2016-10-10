using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Projectiles.Npc

{
	public class CometHead : ModProjectile
	{
		
		public override void SetDefaults()
		{
			projectile.name = "Comet Head";
			projectile.width = 18;
			projectile.height = 20;
			projectile.timeLeft = 100;
			projectile.penetrate = 1;
			projectile.ignoreWater = false;
			projectile.hostile = true;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.extraUpdates = 1;
			projectile.tileCollide = true;
			Main.projFrames[projectile.type] = 3;
		}
		
		public void onSpawn()
		{
			for (int i = 0; i < 30; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Comet"));
				}
				if (Main.rand.Next(1) == 0)
				{
					projectile.frame = 0;
				}
				else if (Main.rand.Next(1) == 0)
				{
					projectile.frame = 1;
				}
				else
				{
					projectile.frame = 2;
				}
		}
		
		public override void AI()
		{
			if (projectile.timeLeft == 100)
			{
				onSpawn();
			}
			projectile.rotation += 0.1f;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Comet"));
			
		}

        public override void Kill(int t)
        {
            for (int i = 0; i < 50; i++)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Comet"));
            }
        }
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			int a = 0;
			while (a < 50)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
				a++;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int b = 0;
			while (b < 50)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
				b++;
			}
		}
	}
}