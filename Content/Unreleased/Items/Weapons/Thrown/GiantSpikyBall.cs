using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Thrown
{
public class GiantSpikyBall : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Giant Spike Ball"; //Its display name
			item.damage = 38; //The damage
			item.width = 34; //Item width
			item.height = 34; //Item height
			item.maxStack = 999; //How many of this item you can stack
			item.thrown = true;
			item.toolTip = "Woah, that's a huge spike ball!"; //The item’s tooltip
			item.useTime = 20; //How long it takes for the item to be used
			item.useAnimation = 20; //How long the animation of the item takes
			item.knockBack = 3f; //How much knockback the item produces
            item.UseSound = SoundID.Item1; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 1; //How the weapon is held, 5 is the gun hold style
			item.value = 100; //How much the item is worth
			item.rare = 4; //The rarity of the item
			item.crit = 6;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("GiantSpikyBall"); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires	
			item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}
	}
}