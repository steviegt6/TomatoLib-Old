using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;

namespace TomatoLib.Core
{
    public static partial class TomatoLoader
    {
        internal static IDictionary<string, Assembly> mods = new Dictionary<string, Assembly>();

        internal static void UnloadContent()
        {
            mods = null;
        }

        //Actually *technically* POSTSetupContent but I wanna keep the naming relatively consistent with tModLoader.
        internal static void SetupContent()
        {
            foreach (KeyValuePair<string, Assembly> mod in mods)
            {
                IEnumerable<Type> enumTypes = mod.Value.GetTypes().OrderBy(i => i.FullName, StringComparer.InvariantCulture).Where(j => !j.IsAbstract && j.IsClass);

                //For when I add ModRarity. :thepoggening:
                /*foreach (Type modRarity in enumTypes.Where(k => k.IsSubclassOf(typeof(ModRarity))))
                {
                }*/
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