using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.ModLoader;
using TomatoLib.Items;

namespace TomatoLib
{
    public class TomatoLib : Mod
    {
        private static float rotationTime = 0f;
        private Texture2D vanillaLogo;
        private Texture2D vanillaLogo2;

        public override void Load()
        {
            vanillaLogo = Main.logoTexture;
            vanillaLogo2 = Main.logo2Texture;
        }

        public override void PostSetupContent()
        {
			Main.logoTexture = Main.logo2Texture = ModContent.GetTexture("TomatoLib/Core/TomatoLogo");

            Main.OnPostDraw += Main_OnPostDraw;
        }

		public override void Unload()
		{
			Main.logoTexture = vanillaLogo;
			Main.logo2Texture = vanillaLogo2;

			Main.OnPostDraw -= Main_OnPostDraw;
		}

        private void Main_OnPostDraw(GameTime obj)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            rotationTime += 0.1f;

            if (Main.gameMenu && ModLoader.GetMod("TerrariaOverhaul") == null)
            {
                Texture2D tomato = Main.itemTexture[ModContent.ItemType<Tomato>()];
                float tomatoRotation = rotationTime * 1.5f;
                string text = "Running on Tomato Lib v" + Version;

                Vector2 textPosition = new Vector2(35f, 8f);
                Vector2 tomatoSize = tomato.Size() * 0.5f;
                Vector2 tomatoPositon = textPosition + tomatoSize;
                tomatoPositon.X -= 28f;
                tomatoPositon.Y -= 2f;

                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, text, textPosition, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(tomato, tomatoPositon, null, Color.White, tomatoRotation, tomatoSize, 1f, SpriteEffects.None, 0f);

                Main.DrawCursor(Main.DrawThickCursor());
            }

            spriteBatch.End();
        }
	}
}