using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using TomatoLib.Content;
using TomatoLib.Content.UI;
using TomatoLib.Core;

namespace TomatoLib
{
    //TODO: Port tModLoader Menu UIs to here and make them usable. :)
    public partial class TomatoLib : Mod
    {
        public static bool easterEgg = false; //The bool used for setting the logo texture to that of a tomato along with changing the "tomato text" to rainbow.
        public static Preferences ModdedConfiguration = new Preferences(Main.SavePath + Path.DirectorySeparatorChar.ToString() + "TomatoLib_Config.json");

        internal UIInfoMessage infoMessage = new UIInfoMessage();
        internal UIModItem_Hook uIModItem_Hook = new UIModItem_Hook();
        internal static Assembly TerrariaAssembly = typeof(Main).Assembly;
        internal static bool showUpdateMessage;

        private static float tomatoRotation = 0f;
        private Texture2D vanillaLogo;
        private Texture2D vanillaLogo2;
        private SpriteBatch spriteBatch = Main.spriteBatch;

        public override void Load()
        {
            #region Version Checking

            TomatoLoader.LoadVersion();

            if (TomatoLoader.lastLaunchedVersion < TomatoLoader.version)
            {
                showUpdateMessage = true;
            }
            else
            {
                showUpdateMessage = false;
            }

            #endregion Version Checking

            TomatoLoader.InitializeContent();

            TomatoLoader.AddMod(this);

            easterEgg = Main.rand.NextBool(100);

            TomatoLoader.SaveVersion();

            vanillaLogo = Main.logoTexture;
            vanillaLogo2 = Main.logo2Texture;

            HookEvents.UIModItem_OverrideInitialize += uIModItem_Hook.HookEvents_UIModItem_OverrideInitialize;

            On.Terraria.Item.Prefix += Item_Prefix;
            On.Terraria.ItemText.NewText += ItemText_NewText;
            On.Terraria.Main.MouseText += Main_MouseText;
        }

        public override void PostSetupContent()
        {
            TomatoLoader.SetupContent();

            if (easterEgg)
            {
                Main.logoTexture = Main.logo2Texture = ModContent.GetTexture("TomatoLib/Content/UI/TomatoLogo");
            }

            Main.OnPostDraw += Main_OnPostDraw;
        }

        public override void Unload()
        {
            TomatoLoader.UnloadContent();

            Main.logoTexture = vanillaLogo;
            Main.logo2Texture = vanillaLogo2;
            vanillaLogo = null;
            vanillaLogo2 = null;

            Main.OnPostDraw -= Main_OnPostDraw;
        }
    }
}