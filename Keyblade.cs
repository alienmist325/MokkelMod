using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod
{
    //fix 3rd time not working problem
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
        Player pl;
        int charge = 0;
        int delay;
        int proj;
        static int chargedVal = 60; //multiple of 4
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
                item.useStyle = 5;
                item.useTime = 1;
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

        public void Convert(int i, int j, int size = 4)
        {

            if (IsChest(Main.tile[i, j].type))
            {
                int num = i;
                int num2 = j;
                if (Main.tile[i, j].frameX % 36 != 0)
                {
                    num--;
                }
                if (Main.tile[i, j].frameY % 36 != 0)
                {
                    num2--;
                }
                Chest.Unlock(num, num2);
            }
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (delay > 0)
            {
                delay--;
            }
            else
            {
                charge = 0;
                if (pl != null)
                {
                    foreach (Projectile p in Main.projectile)
                    {
                        if (p.active && p.owner == pl.whoAmI && p.type == mod.ProjectileType("Bolt") && p.ai[0] != 4)
                        {
                            p.Kill();
                        }
                    }
                }
                
            }
        }

        public override void UseStyle(Player player)
        {
            if (player.altFunctionUse == 2)
            {

                player.itemRotation = player.direction * 3.14f * 0.25f;
                float d = new Vector2(item.width, item.height).Length();
                player.itemLocation += new Vector2(0, d * -0.4f);
            }
        }

        public static bool IsChest(int type)
        {
            return type == 21 || TileLoader.ModChestName(type).Length > 0;
        }

        public void SlowPlayerDown(Player player)
        {
            if (player.direction > 0)
            {
                if (player.velocity.X > -1.5)
                {
                    player.velocity += new Vector2(-0.5f * player.direction, 0);
                }
            }
            else
            {
                if (player.velocity.X < 1.5)
                {
                    player.velocity += new Vector2(-0.5f * player.direction, 0);
                }
            }
        }

        public void UnlockChestsInSwing()
        {
            cx = (hx / 16);
            cy = (hy / 16);
            noX = (int)Math.Ceiling((double)(hw / 16));
            noY = (int)Math.Ceiling((double)(hh / 16));

            for (int x = 0; x < noX; x++)
            {
                for (int y = 0; y < noY; y++)
                {
                    //Projectile.NewProjectile(new Vector2(16 * (cx + x) + 8, 16 * (cy + y) + 8), Vector2.Zero, mod.ProjectileType("TestPos"), 0, 0);
                    if (IsChest(Main.tile[cx + x, cy + y].type))
                    {
                        Chest.Unlock(cx + x, cy + y);
                    }
                }
            }
        }

        public override bool UseItem(Player player)
        {
            pl = player;
            ErrorLogger.Log(charge.ToString());
            if (player.altFunctionUse == 2)
            {
                if (charge == 1)
                {
                    Projectile.NewProjectile(player.itemLocation, Vector2.Zero, mod.ProjectileType("Bolt"),0,0,player.whoAmI);
                }
                if (charge == 2)
                {
                    foreach (Projectile p in Main.projectile)
                    {
                        if (p.active && p.owner == player.whoAmI && p.type == mod.ProjectileType("Bolt"))
                        {
                            proj = p.whoAmI;
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    if (charge == (chargedVal * i) / 5)
                    {
                        Main.projectile[proj].ai[0] += 1;
                    }
                }
                if (charge == chargedVal)
                {
                    charge = 0;
                }
                else
                {
                    charge++;
                    delay = 20;
                }
                
                
            }
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            hx = hitbox.X;
            hy = hitbox.Y;
            hh = hitbox.Height;
            hw = hitbox.Width;
            
			if (player.altFunctionUse == 2)
			{
                SlowPlayerDown(player);
                Convert((int)(hitbox.X + (float)(hitbox.Width / 2)) / 16, (int)(hitbox.Y + (float)(hitbox.Height / 2)) / 16, 2);
                //int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
                //Main.dust[dust].noGravity = true;
                //Main.dust[dust].velocity.X += player.direction * 2f;
                //Main.dust[dust].velocity.Y += 0.2f;
            }
			else
			{
                UnlockChestsInSwing();
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
			}
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
