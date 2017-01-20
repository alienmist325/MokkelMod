using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Necromancer
{
    public class NecromancerMask : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Necromancer Mask";
            item.width = 28;
            item.height = 22;
            item.toolTip = "15% increased minion damage and +1 minion";
            item.defense = 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("NecromancerRobe") && legs.type == mod.ItemType("NecromancerPants");
        }
        
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void UpdateArmorSet(Player Player)
        {
			Player.setBonus = "20% increased movement speed";
			Player.moveSpeed = 1.2f;
        }

        public override void UpdateEquip(Player Player)
        {
            Player.maxMinions += 1;
			Player.minionDamage = 1.15f;
        }
    }
}
