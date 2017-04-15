using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items
{
    public class DynastyKey : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dynasty Key";
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.value = 300;
            item.rare = 4;
        }
    }
}
