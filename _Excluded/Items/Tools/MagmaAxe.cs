using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Items.Tools
{
	public class MagmaAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Waraxe";
			item.damage = 86;
			item.width = 56;
			item.height = 44;
			item.maxStack = 1;
			item.useTime = 15;
			item.useAnimation = 15;
			item.knockBack = 5;
			item.axe = 40;
			item.useStyle = 1;
			item.value = 10000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
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