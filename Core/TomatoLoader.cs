using System;
using System.Collections.Concurrent;
using System.Reflection;
using Terraria.ModLoader;

namespace TomatoLib.Core
{
    public static partial class TomatoLoader
    {
        internal static readonly Version version = new Version(1, 0, 0);
        internal static Version lastLaunchedVersion;

        public static void AddMod(Mod mod)
        {
            if (mod != null)
            {
                if (!(bool)mod.GetType().GetField("loading", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(mod))
                {
                    throw new Exception("AddMod can only be called from Mod.Load");
                }

                if (mods.ContainsKey(mod.Name))
                {
                    throw new Exception($"Two mods with the same name were added: {mod.Name}. Perhaps you called AddMod twice?");
                }

                mods.Add(mod.Name, mod.Code);
            }
        }
    }
}