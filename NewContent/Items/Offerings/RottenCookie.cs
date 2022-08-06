using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEnoughSickles.NewContent.Items.Offerings
{
    public class RottenCookie : Offering
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Cookie");
            Tooltip.SetDefault("Looks terrible.");
        }
    }
}
