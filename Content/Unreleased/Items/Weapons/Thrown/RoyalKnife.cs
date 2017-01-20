using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Thrown
{
public class RoyalKnife : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Royal Throwing Knife"; //Its display name
			item.damage = 55; //The damage
			item.width = 18; //Item width
			item.height = 36; //Item height
			item.maxStack = 999; //How many of this item you can stack
			item.thrown = true;
			item.toolTip = "'Throwing knives on steroids!'"; //The item’s tooltip
			item.useTime = 20; //How long it takes for the item to be used
			item.useAnimation = 20; //How long the animation of the item takes
			item.knockBack = 2f; //How much knockback the item produces
            item.UseSound = SoundID.Item1; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 1; //How the weapon is held, 5 is the gun hold style
			item.value = 1; //How much the item is worth
			item.rare = 4; //The rarity of the item
			item.crit = 10;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("RoyalKnife"); //What the item shoots, retains an int value | *
			item.shootSpeed = 11f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RoyalIngot", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}