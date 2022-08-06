using JustEnoughSickles.NewContent.Items.Materials;
using JustEnoughSickles.NewContent.Items.Offerings;
using JustEnoughSickles.NewContent.Items.Weapons.Sickles;
using JustEnoughSickles.NewContent.NPCs.Souls;
using Terraria.ModLoader;

namespace JustEnoughSickles.NewContent.Utils
{
    public class JESIDs
    {
        public class NPCIDs
        {
            public class Souls
            {
                public static readonly int Inferno = ModContent.NPCType<Inferno>();
                public static readonly int Frost = ModContent.NPCType<Frost>();
                public static readonly int Shadow = ModContent.NPCType<Shadow>();
                public static readonly int Light = ModContent.NPCType<Light>();
            }
        }
        public class ItemIDs
        {
            public class Weapon
            {
                public class Sickle
                {
                    public static readonly int Coblat = ModContent.ItemType<CobaltSickle>();
                    public static readonly int Golden = ModContent.ItemType<GoldenSickle>();
                }
            }
            public class Misc
            {
                public class Offering
                {
                    public static readonly int BeePawsInHoneySauce = ModContent.ItemType<BeePawsInHoneySauce>();
                    public static readonly int ReasonableStew = ModContent.ItemType<ReasonableStew>();
                    public static readonly int RottenCookie = ModContent.ItemType<RottenCookie>();
                    public static readonly int RoyalCocktail = ModContent.ItemType<RoyalCocktail>();
                    public static readonly int SuspiciousLookingChowder = ModContent.ItemType<SuspiciousLookingСhowder>();
                }
                public class Material
                {
                    public static readonly int Uranium = ModContent.ItemType<Uranium>();
                }
            }
        }
    }
}
