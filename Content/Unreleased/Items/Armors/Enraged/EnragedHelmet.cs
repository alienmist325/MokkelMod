using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Enraged
{
    public class EnragedHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Enraged Helmet";
            item.width = 18;
            item.height = 18;
            item.toolTip = "?";

            item.defense = 10; // ??
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("EnragedBreastplate") && legs.type == mod.ItemType("EnragedGreaves");
        }

        public override void UpdateArmorSet(Player Player)
        {
            Player.AddBuff(mod.BuffType("EnragedBuff"), 2);
        }

        public override void UpdateEquip(Player Player)
        {
            // Add item stat changes
        }
    }
}
