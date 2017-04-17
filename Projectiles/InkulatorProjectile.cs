using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class InkulatorProjectile : ModProjectile 
	{
		public override void SetDefaults()
		{
			    projectile.name = "InkulatorStream";
				projectile.width = 32;
				projectile.height = 32;
				projectile.aiStyle = 12;
				projectile.alpha = -1;
				projectile.penetrate = -1;
				projectile.extraUpdates = 2;
				projectile.ignoreWater = true;
				projectile.magic = true;
				projectile.friendly = true;
        }
	}
	
}
