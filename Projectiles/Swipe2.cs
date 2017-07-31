using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{
    public class Swipe2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swipe");
        }

        public override void SetDefaults()
        {
            projectile.width = 92;
            projectile.height = 45;
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
            Projectile ow = Main.projectile[projectile.owner];
            projectile.position = ow.position + new Vector2(ow.width, ow.height);
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
