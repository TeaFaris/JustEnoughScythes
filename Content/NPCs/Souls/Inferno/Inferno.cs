using Microsoft.Xna.Framework;

namespace JustEnoughScythes.Content.NPCs.Souls.Inferno
{
    public class Inferno : SoulMob
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault($"Inferno soul");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            SoulType = SoulType.Inferno;
            MainColor = new Color(235, 109, 30);
        }
    }
}
