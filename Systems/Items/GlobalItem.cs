using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace JustEnoughSickles.Systems.Items
{
    public class GlobalItem : Terraria.ModLoader.GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Main.LocalPlayer.GetWeaponArmorPenetration(item) <= 1)
                return;
            tooltips.Insert(2, new TooltipLine(Mod, "Penetration", $"{Main.LocalPlayer.GetWeaponArmorPenetration(item)} armor penetration"));
        }
    }
}
