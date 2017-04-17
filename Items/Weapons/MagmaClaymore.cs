using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class MagmaClaymore : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Claymore";
			item.damage = 110;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 200000;
			item.rare = 7;
			item.scale = 1.2f;
            item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("MagmaClaymore");
			item.shootSpeed = 10f;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaIngot", 22);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}