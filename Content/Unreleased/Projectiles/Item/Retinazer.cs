using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{
    public class Retinazer : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.damage = 47;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.TheEyeOfCthulhu;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 800)
            {
                projectile.frame = 1;
            }

            projectile.frameCounter++;
            if (projectile.frameCounter % 40 == 0)
            {
                float rotation = (float)(Main.rand.Next(0, 361) * (Math.PI / 180));
                Vector2 velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, ProjectileID.PinkLaser, projectile.damage, projectile.owner, 0, 0f);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].velocity *= 6f;
            }
        }
    }
}