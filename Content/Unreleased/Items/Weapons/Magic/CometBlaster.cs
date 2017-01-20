using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Magic
{
public class CometBlaster : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Comet Blaster"; //Its display name
			item.damage = 63; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 30; //Item width
			item.height = 22; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots out small laser pulses"; //The item’s tooltip
			item.useTime = 15; //How long it takes for the item to be used
			item.useAnimation = 15; //How long the animation of the item takes
			item.knockBack = 1f; //How much knockback the item produces
            item.UseSound = SoundID.Item12; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 40000; //How much the item is worth
			item.rare = 6; //The rarity of the item
			item.crit = 9;
			item.mana = 5;
			item.shoot = mod.ProjectileType("CometBlaster"); //What the item shoots, retains an int value | *
			item.shootSpeed = 8f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CometBar", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
