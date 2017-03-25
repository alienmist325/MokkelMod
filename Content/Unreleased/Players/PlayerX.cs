using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Unreleased.Players
{
    public class PlayerX : ModPlayer
    {
        public bool locked = false;

        public bool empowered;
        public bool inscribed;
        public bool enraged;

        public int armorSetStacks;
        public int armorSetStacksCooldown;

        public override void PreUpdate()
        {
            if (locked)
            {
                foreach (Projectile p in Main.projectile)
                {
                    if (p.name == "TestPos")
                    {
                        p.ai[0] = 1;
                    }
                }
            }
        }
        public override void ResetEffects()
        {
            this.empowered = false;
            this.inscribed = false;
            this.enraged = false;

            if (armorSetStacks > 0)
            {
                if (armorSetStacksCooldown-- <= 0)
                {
                    armorSetStacks--;
                    armorSetStacksCooldown = 180;
                }
            }
        }

        public override void PostUpdateBuffs()
        {
            if (this.empowered)
            {
                player.statDefense += armorSetStacks;

                player.moveSpeed -= 0.2F;
            }
            else if (this.inscribed)
            {
                player.lifeRegenTime += (int)Math.Floor((double)this.armorSetStacks / 10);
                player.moveSpeed += 0.02F * this.armorSetStacks;
            }
            else if (this.enraged)
            {
                player.meleeDamage += 0.01F * armorSetStacks;
                player.meleeSpeed += 0.01F * armorSetStacks;

                if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        int newDust = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2f);
                        Dust dust = Main.dust[newDust];
                        dust.noGravity = true;
                        dust.noLight = true;
                        dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
                        dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
                    }
                }
            }
            else
            {
                armorSetStacks = 0;
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (this.inscribed || this.enraged)
            {
                int maxStacks = 0;
                if (this.inscribed) maxStacks = 20;
                if (this.enraged)
                {
                    maxStacks = 30;
                    if (armorSetStacks >= 20)
                        target.AddBuff(mod.BuffType("RagingInferno"), 120);
                }

                if (armorSetStacks < maxStacks)
                    armorSetStacks++;
                else
                    armorSetStacks = maxStacks;

                armorSetStacksCooldown = 120;
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (this.empowered)
            {
                int maxStacks = 0;
                if (this.empowered) maxStacks = 40;

                if (armorSetStacks < maxStacks)
                    armorSetStacks++;
                else
                    armorSetStacks = maxStacks;

                armorSetStacksCooldown = 120;
            }
        }
    }
}
