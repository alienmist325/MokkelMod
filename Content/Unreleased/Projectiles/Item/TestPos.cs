using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{
	public class TestPos : ModProjectile
	{
		
		public override void SetDefaults()
		{
			projectile.name = "TestPos";
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 100;//2
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.tileCollide = false;
            projectile.ai[0] = -1;
		}

        public override void AI()
        {
            projectile.timeLeft +=
                projectile.ai[0] == 1 ?
                1 : 0;
           // ErrorLogger.Log(projectile.whoAmI.ToString() + " " + projectile.ai[0].ToString());
        }
    }
}