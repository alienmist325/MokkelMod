using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class Sandstorm : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm");
            Tooltip.SetDefault("Sends out a raging tornado.");
        }

        public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
			item.width = 28;
			item.height = 32;
			item.maxStack = 1;
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.useStyle = 5;
			item.value = 1;
			item.rare = 3;
			item.crit = 7;
			item.mana = 5;
			item.shoot = mod.ProjectileType("Sandstorm");
			item.shootSpeed = 7f;
			item.autoReuse = false;
		}
	}
}
