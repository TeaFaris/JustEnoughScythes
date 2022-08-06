using Terraria;
using Terraria.ID;

namespace JustEnoughSickles.NewContent.Items.Weapons.Sickles
{
    public class GoldenSickle : SickleBase
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Sickle");
            Tooltip.SetDefault("Golden Sickle made from gold.");
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
