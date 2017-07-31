using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class MagmaBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Bow";
			item.damage = 104;
			item.ranged = true;
			item.width = 30;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 7;
            item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 1; 
			item.shootSpeed = 13f;
			item.useAmmo = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaIngot", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 0f * 0.0174f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double startAngle = Math.Atan2(speedX, speedY)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 1;i++ )
			{
				offsetAngle = startAngle + deltaAngle * i;
				Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), 41, damage, knockBack, item.owner);
			}
			return false;
		}
	}
}