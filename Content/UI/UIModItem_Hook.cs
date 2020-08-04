namespace TomatoLib.Content.UI
{
    internal class UIModItem_Hook
    {
        //internal FieldInfo _mod = TomatoLib.TerrariaAssembly.GetType("Terraria.ModLoader.UI.UIModItem").GetField("_mod", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        //internal string ModName = TomatoLib.TerrariaAssembly.GetType("Terraria.ModLoader.UI.UIModItem").GetField("Name", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)?.ToString();

        //private string modsPath = "Terraria.ModLoader.Mod";


        //TODO: Recreate all of this method using reflection.
        //TODO: Add prefix count, etc.
        internal void HookEvents_UIModItem_OverrideInitialize(HookEvents.Orig_UIModItem_Initialize orig, object self)
        {
            orig(self);

            //tModLoader drawing code.
            /*if (loadedMod != null)
            {
                _loaded = true;
                int[] values = { loadedMod.items.Count, loadedMod.npcs.Count, loadedMod.tiles.Count, loadedMod.walls.Count, loadedMod.buffs.Count, loadedMod.mountDatas.Count };
                string[] localizationKeys = { "ModsXItems", "ModsXNPCs", "ModsXTiles", "ModsXWalls", "ModsXBuffs", "ModsXMounts" };
                int xOffset = -40;
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] > 0)
                    {
                        Texture2D iconTexture = Main.instance.infoIconTexture[i];
                        _keyImage = new UIHoverImage(iconTexture, Language.GetTextValue($"tModLoader.{localizationKeys[i]}", values[i]))
                        {
                            Left = { Pixels = xOffset, Percent = 1f }
                        };
                        Append(_keyImage);
                        xOffset -= 18;
                    }
                }
            }*/
        }
    }
}
