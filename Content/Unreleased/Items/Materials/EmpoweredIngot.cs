using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class EmpoweredIngot : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Empowered Ingot";
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			AddTooltip("Infused with the essence of The Destroyer");
			item.value = 5000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantIngot");
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}