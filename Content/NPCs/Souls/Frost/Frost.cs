using Microsoft.Xna.Framework;

namespace JustEnoughSickles.Content.NPCs.Souls.Frost
{
    public class Frost : SoulMob
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault($"Frost soul");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            SoulType = SoulType.Frost;
            MainColor = new Color(136, 210, 242);
        }
    }
}
