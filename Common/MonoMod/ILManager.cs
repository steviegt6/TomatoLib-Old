using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace TomatoLib.Common.MonoMod
{
    public static class ILManager
    {
        private static Dictionary<Mod, List<ILEdit>> _ilEdits;

        public static ILEdit GetILEdit<T>(Mod modInstance) =>
            _ilEdits[modInstance].First(il => il.GetType() == typeof(T));

        internal static void Initialize()
        {
            _ilEdits = new Dictionary<Mod, List<ILEdit>>();

            foreach (Mod mod in ModLoader.Mods)
            {
                List<ILEdit> ilEdits = new List<ILEdit>();

                foreach (Type type in mod.Code.GetTypes())
                {
                    if (type.IsAbstract || type.GetConstructor(new Type[] { }) == null ||
                        !type.IsSubclassOf(typeof(ILEdit)) || !(Activator.CreateInstance(type) is ILEdit ilEdit))
                        continue;

                    ilEdit.Mod = mod;
                    ilEdit.Name = ilEdit.Name;

                    string name = ilEdit.Name;
                    if (!ilEdit.Autoload(ref name))
                        continue;

                    ilEdit.Name = name;
                    ilEdits.Add(ilEdit);
                }

                _ilEdits.Add(mod, ilEdits);
            }
        }

        internal static void Uninitialize() => _ilEdits = null;

        internal static void LoadILEdits(Mod mod)
        {
            foreach (ILEdit ilEdit in _ilEdits[mod])
                ilEdit.Load();
        }

        internal static void UnloadILEdits(Mod mod)
        {
            foreach (ILEdit ilEdit in _ilEdits[mod])
                ilEdit.Unload();
        }
    }
}