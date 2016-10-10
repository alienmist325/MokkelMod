using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.LivingWood
{
    public class LivingWoodHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Livingwood Helmet";
            item.width = 18;
            item.height = 18;
            item.toolTip = "?";

            item.defense = 10; // ??
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LivingwoodBreastplate") && legs.type == mod.ItemType("LivingwoodGreaves");
        }

        public override void UpdateEquip(Player Player)
        {
            // Add item stat changes
        }
    }
}
