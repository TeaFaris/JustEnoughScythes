using JustEnoughSickles.Content.Items.Materials.Uranium;
using JustEnoughSickles.Content.Items.Offerings.BeePawsInHoneySauce;
using JustEnoughSickles.Content.Items.Offerings.ReasonableStew;
using JustEnoughSickles.Content.Items.Offerings.RottenCookie;
using JustEnoughSickles.Content.Items.Offerings.RoyalCocktail;
using JustEnoughSickles.Content.Items.Offerings.SuspiciousLookingChowder;
using JustEnoughSickles.Content.Items.Weapons.Reaper.CobaltSickle;
using JustEnoughSickles.Content.Items.Weapons.Reaper.GoldenSickle;
using Terraria.ModLoader;

namespace JustEnoughSickles.Utils.IDs
{
    public class JESItemID
    {
        public class Sickle
        {
            public static readonly int Coblat = ModContent.ItemType<CobaltSickle>();
            public static readonly int Golden = ModContent.ItemType<GoldenSickle>();
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
