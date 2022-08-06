using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace JustEnoughSickles.NewContent.Utils
{
    public static class tModLoaderExtentions
    {
        public static IList<T> Swap<T>(this IList<T> List, int IndexA, int indexB)
        {
            T Tmp = List[IndexA];
            List[IndexA] = List[indexB];
            List[indexB] = Tmp;
            return List;
        }
        public static Type GetTypeByName(string Name)
        {
            foreach (var Assembly in AppDomain.CurrentDomain.GetAssemblies().Reverse())
            {
                var TT = Assembly.GetType(Name);
                if (TT != null)
                    return TT;
            }
            return null;
        }
        public static TModPlayer GetModPlayer<TModPlayer>(this Entity Entity) where TModPlayer : ModPlayer => ((Player)Entity).GetModPlayer<TModPlayer>();
        public static FieldInfo[] GetReadonlyFields<T>()
        {
            FieldInfo[] AllFields = typeof(T).GetFields();
            return AllFields.Where(x => x.IsInitOnly).ToArray();
        }
    }
}
