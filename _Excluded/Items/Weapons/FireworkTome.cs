using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
public class FireworkTome : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Fireworks"; //Its display name
			item.damage = 35; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 28; //Item width
			item.height = 32; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'Baby you're a firework!'"; //The item’s tooltip
			item.useTime = 20; //How long it takes for the item to be used
			item.useAnimation = 20; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 4f; //How much knockback the item produces
            item.UseSound = SoundID.Item73; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 60000; //How much the item is worth
			item.rare = 3; //The rarity of the item
			item.crit = 8;
			item.mana = 7;
			item.shoot = mod.ProjectileType("FireworkTome"); //What the item shoots, retains an int value | *
			item.shootSpeed = 11f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
	}
}
