using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
public class CobaltStaff : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Cobalt Staff"; //Its display name
			item.damage = 38; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 52; //Item width
			item.height = 52; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots magic bolts in bursts of three"; //The item’s tooltip
			item.useTime = 10; //How long it takes for the item to be used
			item.useAnimation = 30; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 1f; //How much knockback the item produces
            item.UseSound = SoundID.Item43; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 1; //How much the item is worth
			item.rare = 4; //The rarity of the item
			item.crit = 4;
			item.mana = 10;
			item.shoot = mod.ProjectileType("CobaltStaff"); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
