using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class MagmaClaymore : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Magma Claymore"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 54; //Set the hitbox width
			projectile.height = 52; //Set the hitbox height
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.melee = true; //Tells the game whether it is a ranged projectile or not
			projectile.scale = 2f;
			projectile.aiStyle = 4; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void AI()
        {

			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            }
			
			Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
        }
		
		
		public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            n.AddBuff(24, 300);
        }
	}
}
