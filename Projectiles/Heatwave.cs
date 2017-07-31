using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MokkelMod.Projectiles
{
	public class Heatwave : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heatwave");
        }

        public override void SetDefaults()
		{
			projectile.width = 16; 
			projectile.height = 16; 
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.damage = 100;
			projectile.timeLeft = 600;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.aiStyle = 99;
			projectile.scale = 1.25f;
			projectile.light = 1f;

		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24,100);
		}
		
		public override void AI()
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
		}
	
	}
}