using Terraria;
using Terraria.ID;

namespace JustEnoughScythes.Content.Items.Weapons.Reaper.CobaltScythe
{
    public class CobaltScythe : ScytheBase
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Scythe");
            Tooltip.SetDefault("Cobalt Scythe made from cobalt.");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed;

            base.SetDefaults();
        }
    }
}
