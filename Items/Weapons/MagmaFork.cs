using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Items.Weapons
{
	public class MagmaFork : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Fork";
			item.damage = 96;
			item.melee = true;
			item.width = 100;
			item.height = 100;
			item.useTime = 30;
			item.useAnimation = 30;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 10000;
			item.shoot = mod.ProjectileType("MagmaFork");
			item.rare = 7;
            item.UseSound = SoundID.Item1;
			item.shootSpeed = 3.7f;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaIngot", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}