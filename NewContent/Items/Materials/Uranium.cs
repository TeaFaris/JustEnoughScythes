using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustEnoughSickles.NewContent.Items.Materials
{
    public class Uranium : ModItem
    {
        public DateTime? TimeOfDefence { get; set; }
        public int Defense { get; set; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Uranium");
            Tooltip.SetDefault("That's uranium bro. Don't touch it.");
        }
        public override void UpdateInventory(Player player)
        {
            if (player.armor[0].netID == ItemID.LeadHelmet &&
                player.armor[1].netID == ItemID.LeadChainmail &&
                player.armor[2].netID == ItemID.LeadGreaves)
                return;
            TimeOfDefence ??= DateTime.Now + TimeSpan.FromSeconds(Defense * 4);
            Main.instance.MouseText($"Radiation level {100f - (TimeOfDefence - DateTime.Now).Value.TotalSeconds / (Defense * 4f / 100f)}%");
            if (DateTime.Now < TimeOfDefence)
                return;

            player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason($"{player.name} was so bad at following directions; It's incradeble he wasn't died years ago."), 25, 1);
        }
        public override bool OnPickup(Player player)
        {
            Defense = player.statDefense;
            return true;
        }
    }
}
