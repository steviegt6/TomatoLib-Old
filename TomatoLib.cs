using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TomatoLib.Core;

namespace TomatoLib
{
    public partial class TomatoLib : Mod
    {
        //The bool used for setting the logo texture to that of a tomato along with changing the "tomato text" to rainbow.
        public static bool easterEgg = false;

        private static float tomatoRotation = 0f;
        private Texture2D vanillaLogo;
        private Texture2D vanillaLogo2;
        private SpriteBatch spriteBatch = Main.spriteBatch;

        public override void Load()
        {
            vanillaLogo = Main.logoTexture;
            vanillaLogo2 = Main.logo2Texture;

            Main.OnPostDraw += Main_OnPostDraw;

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