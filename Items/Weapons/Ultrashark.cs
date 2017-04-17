using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class Ultrashark : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ultrashark";
			item.damage = 40;
			item.ranged = true;
			item.width = 70;
			item.height = 28;
			item.toolTip = "50% chance not to consume ammo";
			item.toolTip2 = "What's next? A Gigashark? Hahaha!";
			item.useTime = 5;
			item.useAnimation = 2;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = ProjectileID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Megashark);
			recipe.AddIngredient(ItemID.IllegalGunParts, 3);
			recipe.AddIngredient(ItemID.Gatligator);
			recipe.AddIngredient(null, "RadiantIngot", 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool ConsumeAmmo(Player p) //Tells the game whether the item consumes ammo or not
        {
			int rand = Main.rand.Next(2); //A random chance... once again
            {
				if(rand == 0) //50 percent chance to make player consume no ammo 
				{
					return false; //No ammo is consumed
				}
                else
				{
					return true; //Ammo is consumed
				}
            }

        }
	}
}