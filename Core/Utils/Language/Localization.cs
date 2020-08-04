using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TomatoLib.Core.Utils.Language
{
    public static class Localization
    {
        /// <summary>
        /// Creates a ModTranslation suitable for config headers and labels (<c>[i:itemID][c/color:displayName]</c>). If you don't want an item, set <c>itemID</c> to <c>0</c>.
        /// </summary>
        /// <param name="internalName">The internal name of your translation. ("$Mods.YourModName.internalName")</param>
        /// <param name="displayName">The text displayed.</param>
        /// <param name="itemID"></param>
        /// <param name="color"></param>
        public static void AddConfigOption(Mod mod, string internalName, string displayName, int itemID, Color color, bool itemAppearsAfterText = false)
        {
            ModTranslation modTranslation = mod.CreateTranslation(internalName);
            string item = itemID > 0 ? $"[i:{itemID}]" : "";

            modTranslation.SetDefault(!itemAppearsAfterText ? item + $"[c/{color.Hex3()}:{displayName}]" : $"[c/{color.Hex3()}:{displayName}]" + item);
            mod.AddTranslation(modTranslation);
        }

        /// <summary>
        /// Creates a ModTranslation suitable for config headers and labels (<c>[i:itemID][c/color:displayName]</c>). If you don't want an item, set <c>itemID</c> to <c>0</c>.
        /// </summary>
        /// <param name="internalName">The internal name of your translation. ("$Mods.YourModName.internalName")</param>
        /// <param name="displayName">The text displayed.</param>
        /// <param name="itemID"></param>
        /// <param name="color"></param>
        public static void AddConfigOption(Mod mod, string internalName, string displayName, int itemID, string color, bool itemAppearsAfterText = false)
        {
            ModTranslation modTranslation = mod.CreateTranslation(internalName);
            string item = itemID > 0 ? $"[i:{itemID}]" : "";

            modTranslation.SetDefault(!itemAppearsAfterText ? item + $"[c/{color}:{displayName}]" : $"[c/{color}:{displayName}]" + item);
            mod.AddTranslation(modTranslation);
        }

        /// <summary>
        /// Creates a ModTranslation suitable for config headers and labels (<c>[i:itemID][c/color:displayName]</c>). If you don't want an item, set <c>itemID</c> to <c>""</c>.
        /// </summary>
        /// <param name="internalName">The internal name of your translation. ("$Mods.YourModName.internalName")</param>
        /// <param name="displayName">The text displayed.</param>
        /// <param name="itemID"></param>
        /// <param name="color"></param>
        public static void AddConfigOption(Mod mod, string internalName, string displayName, string itemID, Color color, bool itemAppearsAfterText = false)
        {
            ModTranslation modTranslation = mod.CreateTranslation(internalName);
            string item = itemID != "" ? $"[i:{mod.ItemType(itemID)}]" : "";

            modTranslation.SetDefault(!itemAppearsAfterText ? item + $"[c/{color.Hex3()}:{displayName}]" : $"[c/{color.Hex3()}:{displayName}]" + item);
            mod.AddTranslation(modTranslation);
        }

        /// <summary>
        /// Creates a ModTranslation suitable for config headers and labels (<c>[i:itemID][c/color:displayName]</c>). If you don't want an item, set <c>itemID</c> to <c>""</c>.
        /// </summary>
        /// <param name="internalName">The internal name of your translation. ("$Mods.YourModName.internalName")</param>
        /// <param name="displayName">The text displayed.</param>
        /// <param name="itemID"></param>
        /// <param name="color"></param>
        public static void AddConfigOption(Mod mod, string internalName, string displayName, string itemID, string color, bool itemAppearsAfterText = false)
        {
            ModTranslation modTranslation = mod.CreateTranslation(internalName);
            string item = itemID != "" ? $"[i:{mod.ItemType(itemID)}]" : "";

            modTranslation.SetDefault(!itemAppearsAfterText ? item + $"[c/{color}:{displayName}]" : $"[c/{color}:{displayName}]" + item);
            mod.AddTranslation(modTranslation);
        }
    }
}