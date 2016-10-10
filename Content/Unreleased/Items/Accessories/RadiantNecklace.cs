using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Accessories
{
	public class RadiantNecklace : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Radiant Necklace";
			item.width = 26;
			item.height = 32;
			AddTooltip("Radiates with power");
			AddTooltip("+10% speed, +2 minions");
			AddTooltip("+20% melee speed, +10% ranged damage");
			AddTooltip("-20% mana cost");
			item.value = Item.sellPrice(0, 5);
			item.rare = 5;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player Player, bool hideVisual)
		{
			Player.moveSpeed += 0.10f;
			Lighting.AddLight(Player.position, 0.3f, 0.8f, 0.7f);
			Player.maxMinions += 2;
			Player.meleeSpeed += 0.20f;
			Player.rangedDamage += 0.10f;
			Player.manaCost -= 0.20f;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantIngot", 15);
			recipe.AddTile(TileID.Anvils);
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
