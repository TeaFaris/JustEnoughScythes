using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustEnoughScythes.Content.Items.RangedModificators.Scopes.StandardScope
{
    public class StandardScope : ModificatorBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Accuracy = 1.0f;
            ShootSpeed = -0.1f;
            Item.rare = ItemRarityID.Green;
        }
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Standard scope");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }
    }
}
