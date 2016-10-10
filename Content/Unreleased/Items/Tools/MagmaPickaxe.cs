using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Items.Tools
{
	public class MagmaPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Pickaxe";
			item.damage = 65;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.pick = 210;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 7;
			item.useTurn = true;
			item.useSound = 1;
			item.autoReuse = true;
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