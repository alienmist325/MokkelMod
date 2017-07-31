using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Projectiles
{
	public class Fireball : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
        }

        public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 100;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			
		}
		
		public override void AI()
		{
			
			projectile.rotation += 0.3f;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 158);
			
			if (projectile.timeLeft == 1)
			{
				int c = 0;
				while (c < 50)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
					c++;
				}
			}
		}

        public override void Kill(int t)
        {
            for (int i = 0; i < 50; i++)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
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