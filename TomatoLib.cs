using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using TomatoLib.Content;
using TomatoLib.Content.UI;

namespace TomatoLib
{
    public partial class TomatoLib : Mod
    {
        //The bool used for setting the logo texture to that of a tomato along with changing the "tomato text" to rainbow.
        public static bool easterEgg = false;

        internal UIModItem_Hook uIModItem_Hook = new UIModItem_Hook();
        internal static Assembly TerrariaAssembly = typeof(Main).Assembly;

        private static float tomatoRotation = 0f;
        private Texture2D vanillaLogo;
        private Texture2D vanillaLogo2;
        private SpriteBatch spriteBatch = Main.spriteBatch;

        public override void Load()
        {
            vanillaLogo = Main.logoTexture;
            vanillaLogo2 = Main.logo2Texture;

            Main.OnPostDraw += Main_OnPostDraw;
            HookEvents.UIModItem_OverrideInitialize += uIModItem_Hook.HookEvents_UIModItem_OverrideInitialize;

            easterEgg = Main.rand.NextBool(100);

            if (easterEgg)
            {
                Main.logoTexture = Main.logo2Texture = ModContent.GetTexture("TomatoLib/Core/Images/TomatoLogo");
            }
        }

        public override void Unload()
        {
            Main.logoTexture = vanillaLogo;
            Main.logo2Texture = vanillaLogo2;
            vanillaLogo = null;
            vanillaLogo2 = null;

            Main.OnPostDraw -= Main_OnPostDraw;
        }
    }
}