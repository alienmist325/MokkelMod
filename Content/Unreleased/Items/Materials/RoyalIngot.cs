using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class RoyalIngot : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Royal Ingot";
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			AddTooltip("Forged from valuable materials");
			item.value = 5000;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantIngot", 1);
			recipe.AddIngredient(ItemID.HallowedBar, 2);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}