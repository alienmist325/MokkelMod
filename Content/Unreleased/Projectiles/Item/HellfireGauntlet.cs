using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{	
	public class HellfireGauntlet : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Hellfire Gauntlet"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 36; //Set the hitbox width
			projectile.height = 36; //Set the hitbox height
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.magic = true; //Tells the game whether it is a ranged projectile or not
			projectile.aiStyle = 0; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
            projectile.rotation += (float)projectile.direction * 0.5f; //Spins in a good speed
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
        }
		
		public override bool OnTileCollide(Vector2 velocityChange)  
        {
            if (projectile.velocity.X != velocityChange.X)
            {
                projectile.velocity.X = -velocityChange.X+2; 
            }
            if (projectile.velocity.Y != velocityChange.Y)
            {
                projectile.velocity.Y = -velocityChange.Y+2; 
            }
            return false;
		}
		
		public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            n.AddBuff(24, 300);
        }
	}
}
