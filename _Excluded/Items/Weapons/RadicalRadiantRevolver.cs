using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Items.Weapons
{
	public class RadicalRadiantRevolver : ModItem
	{
		public override void SetDefaults()
		{	
			item.width = 54;
			item.height = 38;
			item.name = "Radical Radiant Revolver";
			item.toolTip = "Codename : Triple R";
			item.damage = 1500;
			item.shoot = mod.ProjectileType("RadicalBullet");
			item.shootSpeed = 10f;
			item.ranged = true;
            item.UseSound = SoundID.Item36;
			item.useTime = 50;
			item.noMelee = true;
			item.knockBack = 10f;
			item.useStyle = 5;
			item.useAnimation = 21;
			item.useAmmo = mod.ItemType("RadicalBullet");
			item.scale = 0.75f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantIngot", 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this,1);
			recipe.AddRecipe();
			
		}	
	}
}