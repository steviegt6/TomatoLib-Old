using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TomatoLib.Core.Utils.Lang
{
    public static class LangAndLocalization
    {
        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyMenu." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyMenu(int i) => Language.GetText("LegacyMenu." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyWorldGen." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyWorldGen(int i) => Language.GetText("LegacyWorldGen." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyInterface." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyInterface(int i) => Language.GetText("LegacyInterface." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyMisc." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyMisc(int i) => Language.GetText("LegacyMisc." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyMultiplayer." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyMultiplayer(int i) => Language.GetText("LegacyMultiplayer." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyTooltip." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyTooltip(int i) => Language.GetText("LegacyTooltip." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyChestType." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyChestType(int i) => Language.GetText("LegacyChestType." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyChestType2." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyChestType2(int i) => Language.GetText("LegacyChestType2." + i.ToString());

        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns><c>Language.GetText("LegacyDresserType." + i.ToString())</c></returns>
        public static LocalizedText GetLegacyDresserType(int i) => Language.GetText("LegacyDresserType." + i.ToString());

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