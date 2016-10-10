using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Necromancer
{
    public class NecromancerRobe : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Necromancer Robe";
			item.width = 28;
			item.height = 22;
			item.toolTip = "25% increased summon damage and +1 minion";
			item.defense = 12;
		}

		public override void UpdateEquip(Player Player)
        {
			Player.maxMinions += 1;
			Player.minionDamage = 1.25f;
		}
	}
}