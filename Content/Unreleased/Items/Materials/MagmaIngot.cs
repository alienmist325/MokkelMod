using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class MagmaIngot : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Ingot";
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			AddTooltip("Ouch! Too hot!");
			item.value = 5000;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaOre", 4);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}