using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod
{
	public class Keyblade : ModItem
	{
		int cx;
		int cy;
        int noX;
        int noY;
        int hx;
        int hy;
        int hh;
        int hw;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Keyblade");
			Tooltip.SetDefault("Being both a sword and a key, this weapon can unlock all.");
		}
		public override void SetDefaults()
		{
			item.damage = 86;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                //item.useStyle = 3;
                //item.useTime = 20;
                //item.useAnimation = 20;
                //item.damage = 50;
                //item.shoot = ProjectileID.Bee;
                item.useStyle = 1;
                item.useTime = 10;
                item.useAnimation = 10;
                item.damage = 40;
                item.shoot = 0;
            }
            else
            {
                item.useStyle = 1;
                item.useTime = 20;
                item.useAnimation = 20;
                item.damage = 85;
                item.shoot = 0;
            }
            return base.CanUseItem(player);
        }

        //public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        //{
        //    if (player.altFunctionUse == 2)
        //    {
        //        target.AddBuff(BuffID.Ichor, 60);
        //    }
        //    else
        //    {
        //        target.AddBuff(BuffID.OnFire, 60);
        //    }
        //}
        public static bool IsChest(int type)
        {
            return type == 21 || TileLoader.ModChestName(type).Length > 0;
        }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            hx = hitbox.X;
            hy = hitbox.Y;
            hh = hitbox.Height;
            hw = hitbox.Width;
            
            //if (Main.rand.Next(3) == 0)
            //{
			if (player.altFunctionUse == 2)
			{
				//int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
				//Main.dust[dust].noGravity = true;
				//Main.dust[dust].velocity.X += player.direction * 2f;
				//Main.dust[dust].velocity.Y += 0.2f;
			}
			else
			{
                cx = (hitbox.X / 16);
                cy = (hitbox.Y / 16);
                noX = (int)Math.Ceiling((double)(hitbox.Width / 16));
                noY = (int)Math.Ceiling((double)(hitbox.Height / 16));

                for (int x = 0; x < noX; x++)
                {
                    for (int y = 0; y < noY; y++)
                    {
                        Projectile.NewProjectile(new Vector2(16 * (cx + x) + 8, 16 * (cy + y) + 8), Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0);
                        if (IsChest(Main.tile[cx + x, cy + y].type))
                        {
                            Chest.Unlock(cx + x, cy + y);
                        }
                    }
                }

				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
			}
            //}
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Keybrand, 1);
            recipe.AddIngredient(ItemID.JungleKey, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
