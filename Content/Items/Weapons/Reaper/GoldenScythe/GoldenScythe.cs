using Terraria;
using Terraria.ID;

namespace JustEnoughScythes.Content.Items.Weapons.Reaper.GoldenScythe
{
    public class GoldenScythe : ScytheBase
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Scythe");
            Tooltip.SetDefault("Golden Scythe made from gold.");
        }

        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.White;

            base.SetDefaults();
        }
    }
}
