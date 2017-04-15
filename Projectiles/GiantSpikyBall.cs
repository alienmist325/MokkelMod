using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
 //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{	
	public class GiantSpikyBall : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Giant Spiky Ball"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 34; //Set the hitbox width
			projectile.height = 34; //Set the hitbox height
			projectile.thrown = true;
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
			projectile.aiStyle = 14; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
        }
	}
}