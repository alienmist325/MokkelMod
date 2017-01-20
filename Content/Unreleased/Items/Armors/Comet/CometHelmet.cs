using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Comet
{
    public class CometHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Comet Helmet";
            item.width = 28;
            item.height = 22;
            item.toolTip = "20% increased magic and melee damage";
            item.defense = 14; // ??
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CometSuit") && legs.type == mod.ItemType("CometGreaves");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player Player)
        {
			Player.manaMagnet = true;
			Player.thorns = 0.25f;
			Player.setBonus = "Thorns effect and increased pickup range for stars";
        }

        public override void UpdateEquip(Player Player)
        {
            Player.magicDamage = 1.2f;
			Player.meleeDamage = 1.2f;
        }
    }
}
