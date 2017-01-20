using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class GraniteSlasher : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite Slasher";
			item.damage = 26;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.toolTip = "Shoots out four granite shards";
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 200;
			item.crit = 6;
			item.rare = 3;
			item.shoot = mod.ProjectileType("GraniteSlasher");
			item.shootSpeed = 5f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.0174f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double startAngle = Math.Atan2(speedX, speedY)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 4;i++ )
			{
				offsetAngle = startAngle + deltaAngle * i;
				Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}
	}
}