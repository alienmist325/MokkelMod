using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
public class HellfireGauntlet : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Hellfire Gauntlet"; //Its display name
			item.damage = 98; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 26; //Item width
			item.height = 26; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots a bouncy fireball"; //The item’s tooltip
			item.useTime = 30; //How long it takes for the item to be used
			item.useAnimation = 60; //How long the animation of the item takes
			item.knockBack = 2f; //How much knockback the item produces
            item.UseSound = SoundID.Item20; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 1; //How the weapon is held, 5 is the gun hold style
			item.value = 1; //How much the item is worth
			item.rare = 7; //The rarity of the item
			item.crit = 10;
			item.mana = 8;
			item.shoot = mod.ProjectileType("HellfireGauntlet"); //What the item shoots, retains an int value | *
			item.shootSpeed = 3f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
	}
}
