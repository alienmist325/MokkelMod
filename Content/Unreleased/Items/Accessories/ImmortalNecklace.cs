using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Accessories
{
	public class ImmortalNecklace : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Immortal Necklace";
			item.width = 26;
			item.height = 32;
			AddTooltip("A necklace infused with godly powers...");
			item.value = Item.sellPrice(0, 5);
			item.rare = 4;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player Player, bool hideVisual)
		{
			Player.longInvince = true;
			Player.starCloak = true;
			Player.bee = true;
			Player.panic = true;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SweetheartNecklace);
			recipe.AddIngredient(ItemID.StarVeil);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Neck);
			return true;
		}
	}
}
