using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEnoughSickles.NewContent.NPCs.Souls
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
            MainColor = new Microsoft.Xna.Framework.Color(235, 109, 30);
        }
    }
}
