using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod
{
    public class Bolt : ModProjectile
    {
        Player plyr;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bolt");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 52;
            projectile.timeLeft = 200;
            projectile.penetrate = -1;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.light = 1f;
            projectile.extraUpdates = 1;
            projectile.tileCollide = false;
            projectile.ai[0] = 0;

        }

        public override void AI()
        {
            plyr = Main.player[projectile.owner];
            
            if (projectile.frame == 4)
            {
                projectile.damage = 20;
                projectile.velocity = new Vector2(5 * plyr.direction, 0);
            }
            else
            {
                projectile.timeLeft = 200;
                projectile.position = FindPosition();
                projectile.frame = (int)projectile.ai[0];
            }
        }

        public Vector2 FindPosition()
        {
            Vector2 pos;
            if (plyr.direction > 0)
            {
                pos = plyr.itemLocation + new Vector2(71, 50) - new Vector2(projectile.width/2,projectile.height/2);
            }
            else
            {
                pos = plyr.itemLocation + new Vector2(-25, 50) - new Vector2(projectile.width / 2, projectile.height / 2);
            }
            return pos;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            base.PostDraw(spriteBatch, lightColor);
        }

        public override void Kill(int timeLeft)
        { 
            for(int i = 0; i < 20; i++)
            {
                Dust.NewDust(projectile.position, projectile.height, projectile.width, 176);
            }
            
        }
    }

}
