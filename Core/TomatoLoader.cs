using System;
using System.Reflection;
using Terraria.ModLoader;
using TomatoLib.Core.Utils.API;

namespace TomatoLib.Core
{
    public partial class TomatoLoader
    {
        internal static readonly Version version = new Version(1, 0, 2);
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

        public static void AddRarity(Mod mod, string name, ModRarity rarity)
        {
            if (rarity != null)
            {
                if (rarities.ContainsKey(name))
                {
                    throw new Exception($"You tried to add 2 ModRarities with the same name: {name}. Maybe 2 classes share a classname but in different namespaces while autoloading or you manually called AddRarity with 2 rarities of the same name.");
                }

                rarity.mod = mod;
                rarity.Name = name;
                rarity.Type = ModRarity.ReverseRarityID();

                rarities[name] = rarity;
                ModRarity.rarities.Add(rarity);
                ContentInstance.Register(rarity);
            }
        }

        /// <summary>
        /// Gets the ModRarity instance corresponding to the name.
        /// Returns null is no ModRarity with the given name is found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ModRarity GetRarity(string name) => rarities.TryGetValue(name, out var rarity) ? rarity : null;

        public static int RarityType<T>() where T : ModRarity => ModContent.GetInstance<T>()?.Type ?? 0;
    }
}