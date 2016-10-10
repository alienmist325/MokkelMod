using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class RadiantIngot : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radiant Ingot";
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			AddTooltip("It seems to glow and shine in your hand");
			item.value = 5000;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantOre", 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}