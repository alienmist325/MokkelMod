using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Magic
{
public class StarBlitz : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Star Blitz"; //Its display name
			item.damage = 30; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 32; //Item width
			item.height = 32; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots a slow-moving star"; //The item’s tooltip
			item.useTime = 60; //How long it takes for the item to be used
			item.useAnimation = 60; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 2f; //How much knockback the item produces
            item.UseSound = SoundID.Item43; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 1; //How much the item is worth
			item.rare = 3; //The rarity of the item
			item.crit = 7;
			item.mana = 5;
			item.shoot = mod.ProjectileType("StarBlitz"); //What the item shoots, retains an int value | *
			item.shootSpeed = 4f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
	}
}
