using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Ranged
{
	public class DualingDragons : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Dualing Dragons";
			item.damage = 50;
			item.ranged = true;
			item.width = 70;
			item.height = 28;
			item.toolTip = "Shoots two bullets at once";
			item.toolTip2 = "Bullets become cursed";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 7;
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.CursedBullet; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 18f;
			item.useAmmo = ProjectileID.Bullet;
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 15f * 0.0174f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double startAngle = Math.Atan2(speedX, speedY)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 2;i++ )
			{
				offsetAngle = startAngle + deltaAngle * i;
				Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}
	}
}