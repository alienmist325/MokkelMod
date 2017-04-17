using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Accessories
{
	public class GravitationalGlobe : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Gravitational Globe";
			item.width = 26;
			item.height = 26;
			AddTooltip("Press UP to reverse gravity!");
			item.value = Item.sellPrice(0, 5);
			item.rare = -12;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player Player, bool hideVisual)
		{
			Player.gravControl = true;
			Player.noFallDmg = true;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GravityGlobe);
			recipe.AddIngredient(ItemID.LuckyHorseshoe);
			recipe.AddIngredient(ItemID.GravitationPotion, 20);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
