using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class KingSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "King Sword";
			item.damage = 70;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.toolTip = "Wielded by the ancient kings of history";
			item.useTime = 75;
			item.useAnimation = 75;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 10000;
			item.rare = 6;
			item.scale = 1.75f;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RoyalIngot", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}