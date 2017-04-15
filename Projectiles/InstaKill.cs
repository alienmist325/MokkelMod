using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.UI;
using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class InstaKill : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = ""; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 10; //Set the hitbox width
			projectile.height = 10; //Set the hitbox height
			projectile.timeLeft = 3; //The amount of time the projectile is alive for
			projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.aiStyle = -1; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
            projectile.position = new Vector2(Main.mouseX,Main.mouseY) + Main.screenPosition;
        }
	}
}