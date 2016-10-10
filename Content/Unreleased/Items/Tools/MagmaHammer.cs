using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Items.Tools
{
	public class MagmaHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Hammer";
			item.damage = 80;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
			item.hammer = 100;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 10000;
			item.rare = 7;
			item.useSound = 1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaIngot", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}