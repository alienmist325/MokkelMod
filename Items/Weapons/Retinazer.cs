using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
    public class Retinazer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Retinazer";
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("Retinazer");
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.damage = 47;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.crit = 4;
            item.rare = 10;
        }
    }
}