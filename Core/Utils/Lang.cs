using Terraria.Localization;

namespace TomatoLib.Core.Utils
{
    public static class Lang
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
    }
}
