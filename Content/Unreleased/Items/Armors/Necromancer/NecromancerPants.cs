using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Necromancer
{
    public class NecromancerPants : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Necromancer Pants";
			item.width = 28;
            item.height = 14;
            item.toolTip = "15% increased summon damage and +1 minion";
			item.defense = 9;
		}

		public override void UpdateEquip(Player Player)
        {
            Player.minionDamage = 1.15f;
			Player.maxMinions += 1;
		}
	}
}