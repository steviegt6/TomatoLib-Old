using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;
using TomatoLib.Core.Utils.API;

namespace TomatoLib.Core
{
    public partial class TomatoLoader
    {
        internal static IDictionary<string, Assembly> mods = new Dictionary<string, Assembly>();
        internal static IDictionary<string, ModRarity> rarities = new Dictionary<string, ModRarity>();

        internal static void InitializeContent()
        {
            mods = new Dictionary<string, Assembly>();
            rarities = new Dictionary<string, ModRarity>();
        }

        internal static void UnloadContent()
        {
            mods = null;
            rarities = null;

            Unload();
        }

        internal static void Unload()
        {
            ModRarity.Unload();
        }

        //Actually *technically* POSTSetupContent but I wanna keep the naming relatively consistent with tModLoader.
        internal static void SetupContent()
        {
            foreach (KeyValuePair<string, Assembly> mod in mods)
            {
                IEnumerable<Type> enumTypes = mod.Value.GetTypes().OrderBy(i => i.FullName, StringComparer.InvariantCulture).Where(j => !j.IsAbstract && j.IsClass);

                foreach (Type modRarity in enumTypes.Where(k => k.IsSubclassOf(typeof(ModRarity))))
                {
                    AutoloadRarity(ModLoader.GetMod(mod.Key), modRarity);
                }
            }
        }

        private static void AutoloadRarity(Mod mod, Type type)
        {
            ModRarity rarity = (ModRarity)Activator.CreateInstance(type);

            rarity.mod = mod;
            string name = type.Name;
            if (rarity.Autoload(ref name))
            {
                AddRarity(mod, name, rarity);
            }
        }

        internal static void SaveVersion()
        {
            TomatoLib.ModdedConfiguration.Clear();
            TomatoLib.ModdedConfiguration.Put("TomatoLibVersion", version.ToString());
            TomatoLib.ModdedConfiguration.Save();
        }

        internal static void LoadVersion()
        {
            TomatoLib.ModdedConfiguration.Load();
            lastLaunchedVersion = new Version(TomatoLib.ModdedConfiguration.Get("TomatoLibVersion", version.ToString()));
        }
    }
}