using JustEnoughScythes.Content.Items.Materials.Uranium;
using JustEnoughScythes.Content.Items.Offerings.BeePawsInHoneySauce;
using JustEnoughScythes.Content.Items.Offerings.ReasonableStew;
using JustEnoughScythes.Content.Items.Offerings.RottenCookie;
using JustEnoughScythes.Content.Items.Offerings.RoyalCocktail;
using JustEnoughScythes.Content.Items.Offerings.SuspiciousLookingChowder;
using JustEnoughScythes.Content.Items.Weapons.Reaper.CobaltScythe;
using JustEnoughScythes.Content.Items.Weapons.Reaper.GoldenScythe;
using Terraria.ModLoader;

namespace JustEnoughScythes.Utils.IDs
{
    public class JESItemID
    {
        public class Scythe
        {
            public static readonly int Coblat = ModContent.ItemType<CobaltScythe>();
            public static readonly int Golden = ModContent.ItemType<GoldenScythe>();
        }
        public class Material
        {
            public static readonly int Uranium = ModContent.ItemType<Uranium>();
        }
        public class Offering
        {
            public static readonly int BeePawsInHoneySauce = ModContent.ItemType<BeePawsInHoneySauce>();
            public static readonly int ReasonableStew = ModContent.ItemType<ReasonableStew>();
            public static readonly int RottenCookie = ModContent.ItemType<RottenCookie>();
            public static readonly int RoyalCocktail = ModContent.ItemType<RoyalCocktail>();
            public static readonly int SuspiciousLookingChowder = ModContent.ItemType<SuspiciousLookingChowder>();
        }
    }
}
