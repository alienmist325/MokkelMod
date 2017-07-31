using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Armors
{
	[AutoloadEquip(EquipType.Head)]
    public class CometHelmet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Helmet");
			Tooltip.SetDefault("20% increased magic and melee damage");
		}
		
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
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
