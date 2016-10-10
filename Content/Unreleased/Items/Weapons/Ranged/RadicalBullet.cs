using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Ranged
{
	public class RadicalBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radical Bullet";
			item.damage = 1000;
			item.ranged = true;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.toolTip = "Strong but radical.";
			item.consumable = true;
			item.knockBack = 1.5f;
			item.shoot = mod.ProjectileType("RadicalBullet");
			item.shootSpeed = 16f;
			item.ammo = mod.ItemType("RadicalBullet");
			item.consumable = true;
			item.scale = 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantIngot", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}