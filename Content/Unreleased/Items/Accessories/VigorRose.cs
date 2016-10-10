using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Accessories
{
	public class VigorRose : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Vigor Rose";
			item.width = 20;
			item.height = 44;
			AddTooltip("Health regeneration increased");
			AddTooltip("Automatically drinks healing potions");
			item.value = Item.sellPrice(0, 0, 30);
			item.rare = 3;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player Player, bool hideVisual)
		{
			Player.lifeRegen += 1;
			if(Player.statLife <= (int)Player.statLifeMax/5)
            {
			   Player.QuickHeal();
            }
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.HealingPotion);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
