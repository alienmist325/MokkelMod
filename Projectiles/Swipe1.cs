using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace MokkelMod.Projectiles
{
    public class Swipe : ModProjectile
    {
        bool firstTick = true;
        int dx = 0;
        int dy = 0;
        Vector2 dv;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swipe");
        }

        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 115;
            projectile.timeLeft = 20;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.scale = 1f;
            projectile.light = 1f;
            projectile.tileCollide = false;
            projectile.knockBack = 1f;

        }

        public override void AI()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 158);
            if (!(dx == 0 && dy == 0))
            {
                dv = new Vector2(dx, dy);
                projectile.position += dv;
            }

            if (firstTick)
            {
                firstTick = false;
                Projectile.NewProjectile(projectile.position, Vector2.Zero,mod.ProjectileType("Swipe2"),projectile.damage,projectile.knockBack,projectile.whoAmI);
            }
        }

        public override void Kill(int t)
        {
            for (int i = 0; i < 50; i++)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            int a = 0;
            while (a < 50)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 174);
                a++;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int b = 0;
            while (b < 50)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
                b++;
            }
        }
    }
}
