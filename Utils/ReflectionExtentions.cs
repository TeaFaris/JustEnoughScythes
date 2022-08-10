using System.Linq;
using System.Reflection;

namespace JustEnoughScythes.Content.Utils
{
    public static class ReflectionExtentions
    {
        public static FieldInfo[] GetIDCategory<T>()
        {
            FieldInfo[] AllFields = typeof(T).GetFields();
            return AllFields.Where(x => x.IsInitOnly).ToArray();
        }
    }
}
