using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID; //We are borrowing properties from IDs to easily make a Recipe
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
public class RazorFeathers : ModItem
{
		public override void SetDefaults()
		{
			item.name = "Razor Feathers"; //Its display name
			item.damage = 24; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 28; //Item width
			item.height = 32; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots out razor sharp feathers"; //The item’s tooltip
			item.useTime = 40; //How long it takes for the item to be used
			item.useAnimation = 40; //How long the animation of the item takes
			item.knockBack = 1f; //How much knockback the item produces
            item.UseSound = SoundID.Item1; //The soundeffect played when used 
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 1; //How much the item is worth
			item.rare = 3; //The rarity of the item
			item.crit = 7;
			item.mana = 5;
			item.shoot = mod.ProjectileType("RazorFeathers"); //What the item shoots, retains an int value | *
			item.shootSpeed = 7f; //How fast the projectile fires	
			item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}
	
	    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
			/*Code is made by berberborscing*/
            int spread = 10; //The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 3; i++)
            {
				float vX = speedX +(float)Main.rand.Next(-spread,spread+1) * spreadMult;
                float vY = speedY +(float)Main.rand.Next(-spread,spread+1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false; //Makes sure to not spawn the original projectile
        }
	}
}
