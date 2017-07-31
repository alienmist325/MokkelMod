using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Projectiles
{
	public class TestPos : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TestPos");
        }

        public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
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