using Terraria;
using Terraria.ID;

namespace JustEnoughSickles.NewContent.Items.Weapons.Sickles
{
    public class CobaltSickle : SickleBase
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Sickle");
            Tooltip.SetDefault("Cobalt Sickle made from cobalt.");
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
