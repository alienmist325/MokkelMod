using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class JadeFan : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Jade Fan";
			item.damage = 65;
			item.thrown = true;
			item.width = 44;
			item.height = 44;
			item.toolTip = "Shoots out 5 spikes";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.knockBack = 3;
			item.value = 200;
			item.crit = 10;
			item.rare = 6;
			item.shoot = mod.ProjectileType("JadeFan");
			item.shootSpeed = 14f;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.0174f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double startAngle = Math.Atan2(speedX, speedY)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 5;i++ )
			{
				offsetAngle = startAngle + deltaAngle * i;
				Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}
	}
}