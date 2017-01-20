using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Thrown
{
	public class NinjaGlove : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ninja Glove";
			item.damage = 30;
			item.thrown = true;
			item.width = 26;
			item.height = 26;
			item.toolTip = "10% chance not to consume ammo";
			item.toolTip2 = "Throws empowered shurikens";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 4;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.Shuriken; 
			item.shootSpeed = 16f;
			item.useAmmo = ProjectileID.Shuriken;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 50);
			recipe.AddIngredient(ItemID.Shuriken, 100);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool ConsumeAmmo(Player p) //Tells the game whether the item consumes ammo or not
        {
			int rand = Main.rand.Next(10); //A random chance... once again
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