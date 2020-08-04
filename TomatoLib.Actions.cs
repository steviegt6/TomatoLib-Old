using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using ReLogic.Graphics;

namespace TomatoLib
{
    public partial class TomatoLib : Mod
    {
        private void Main_OnPostDraw(GameTime obj)
        {
            if (Main.gameMenu && ModLoader.GetMod("TerrariaOverhaul") == null)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                Texture2D tomato = ModContent.GetTexture("TomatoLib/Content/Items/Tomato");
                string text = "Running on Tomato Lib v" + Version;

                Vector2 textPosition = new Vector2(tomato.Size().X + 10f, 8f);
                Vector2 tomatoPositon = new Vector2(8f, 6f) + tomato.Size() * 0.5f;

                tomatoRotation += 0.15f;

                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, text, textPosition, easterEgg ? Main.DiscoColor : Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(tomato, tomatoPositon, null, Color.White, tomatoRotation, tomato.Size() * 0.5f, 1f, SpriteEffects.None, 0f);

                Main.DrawCursor(Main.DrawThickCursor()); //So the cursor draws over the added menu text.

                spriteBatch.End();
            }
        }
    }
}