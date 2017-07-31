using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class Inkulator: ModItem
	{
		public override void SetDefaults()
		{
			item.mana = 7;
			item.autoReuse = true;
			item.name = "Inkulator";
			item.useStyle = 5;
			item.useAnimation = 18;
			item.useTime = 6;
			item.knockBack = 4f;
			item.width = 38;
			item.height = 10;
			item.damage = 21;
			item.shoot = 280;
			item.shootSpeed = 10f;
            item.UseSound = SoundID.Item13;
			item.rare = 4;
			item.value = 500000;
			item.toolTip = "Sprays out a shower of ichor";
			item.magic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("InkulatorProjectile");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
		    recipe.AddIngredient(ItemID.Gel, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}