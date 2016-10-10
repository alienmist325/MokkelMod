using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Necromancer
{
    public class NecromancerHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Necromancer Helmet";
            item.width = 28;
            item.height = 22;
            item.toolTip = "10% increased minion damage and +1 minion";
            item.defense = 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("NecromancerRobe") && legs.type == mod.ItemType("NecromancerPants");
        }
		
		 public override void ArmorSetShadows(Player Player, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
        {
            longTrail = true;
        }

        public override void UpdateArmorSet(Player Player)
        {
			Player.setBonus = "20% decreased mana usage and +20 health";
			Player.manaCost = 0.8f;
			Player.statLifeMax2 += 20;
        }

        public override void UpdateEquip(Player Player)
        {
            Player.maxMinions += 1;
			Player.minionDamage = 1.1f;
        }
    }
}
