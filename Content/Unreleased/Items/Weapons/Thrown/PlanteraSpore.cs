using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Thrown
{
public class PlanteraSpore : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Plantera Spore"; //Its display name
			item.damage = 40; //The damage
			item.width = 26; //Item width
			item.height = 26; //Item height
			item.maxStack = 999; //How many of this item you can stack
			item.thrown = true;
			item.useTime = 6; //How long it takes for the item to be used
			item.useAnimation = 6; //How long the animation of the item takes
			item.knockBack = 1f; //How much knockback the item produces
			item.useSound = 1; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 1; //How the weapon is held, 5 is the gun hold style
			item.value = 1500; //How much the item is worth
			item.rare = 6; //The rarity of the item
			item.crit = 6;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("PlanteraSpore"); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires	
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 30f * 0.0174f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			return true;
		}
	}
}