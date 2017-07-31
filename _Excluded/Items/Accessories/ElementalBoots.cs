using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Accessories
{
	public class ElementalBoots : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Elemental Boots";
			item.width = 32;
			item.height = 32;
			AddTooltip("They shake from the elemental powers within");
			item.value = Item.sellPrice(0, 5);
			item.rare = 4;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player Player, bool hideVisual)
		{
			Player.magmaStone = true;
			Player.waterWalk = true;
			Player.fireWalk = true;
			Player.iceSkate = true;
			Player.lavaMax += 420;
			Player.accRunSpeed = 6.75f;
			Player.rocketBoots = 1;
			Player.moveSpeed += 0.10f;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LavaWaders);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(null, "RadiantIngot", 15);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}