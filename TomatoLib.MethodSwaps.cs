using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using TomatoLib.Core.Utils.API;

namespace TomatoLib
{
    public partial class TomatoLib : Mod
    {
        //Checks if the rarity is that of a modded one. If it is, it saves it after prefix' rarity logic gets ran, and resets the rarity.
        private bool Item_Prefix(On.Terraria.Item.orig_Prefix orig, Item self, int pre)
        {
            int originalRarity = 0;

            if (self.rare > ItemRarityID.Purple)
            {
                originalRarity = self.rare;
            }

            orig(self, pre);

            if (originalRarity != 0)
            {
                self.rare = originalRarity;
            }

            return true;
        }

        //Method swap that checks if the item is a coin or not, if it is, it uses the vanilla method, if it isn't, it uses our code which supports custom rarities.
        private void ItemText_NewText(On.Terraria.ItemText.orig_NewText orig, Item newItem, int stack, bool noStack, bool longText)
        {
            if (newItem.type >= ItemID.CopperCoin && newItem.type <= ItemID.PlatinumCoin)
            {
                orig(newItem, stack, noStack, longText);
                return;
            }

            if (!Main.showItemText || newItem.Name == null || !newItem.active || Main.netMode == NetmodeID.Server)
            {
                return;
            }
            for (int k = 0; k < 20; k++)
            {
                if ((!Main.itemText[k].active || (!(Main.itemText[k].name == newItem.AffixName())) || Main.itemText[k].NoStack) | noStack)
                {
                    continue;
                }
                string text3 = newItem.Name + " (" + (Main.itemText[k].stack + stack).ToString() + ")";
                string text2 = newItem.Name;
                if (Main.itemText[k].stack > 1)
                {
                    text2 = text2 + " (" + Main.itemText[k].stack.ToString() + ")";
                }

                _ = Main.fontMouseText.MeasureString(text2);
                Vector2 vector2 = Main.fontMouseText.MeasureString(text3);
                if (Main.itemText[k].lifeTime < 0)
                {
                    Main.itemText[k].scale = 1f;
                }
                if (Main.itemText[k].lifeTime < 60)
                {
                    Main.itemText[k].lifeTime = 60;
                }
                Main.itemText[k].stack += stack;
                Main.itemText[k].scale = 0f;
                Main.itemText[k].rotation = 0f;
                Main.itemText[k].position.X = newItem.position.X + newItem.width * 0.5f - vector2.X * 0.5f;
                Main.itemText[k].position.Y = newItem.position.Y + newItem.height * 0.25f - vector2.Y * 0.5f;
                Main.itemText[k].velocity.Y = -7f;
                if (Main.itemText[k].coinText)
                {
                    Main.itemText[k].stack = 1;
                }
                return;
            }
            int num4 = -1;
            for (int j = 0; j < 20; j++)
            {
                if (!Main.itemText[j].active)
                {
                    num4 = j;
                    break;
                }
            }
            if (num4 == -1)
            {
                double num3 = Main.bottomWorld;
                for (int i = 0; i < 20; i++)
                {
                    if (num3 > Main.itemText[i].position.Y)
                    {
                        num4 = i;
                        num3 = Main.itemText[i].position.Y;
                    }
                }
            }
            if (num4 < 0)
            {
                return;
            }
            string text4 = newItem.AffixName();
            if (stack > 1)
            {
                text4 = text4 + " (" + stack.ToString() + ")";
            }
            Vector2 vector3 = Main.fontMouseText.MeasureString(text4);
            Main.itemText[num4].alpha = 1f;
            Main.itemText[num4].alphaDir = -1;
            Main.itemText[num4].active = true;
            Main.itemText[num4].scale = 0f;
            Main.itemText[num4].NoStack = noStack;
            Main.itemText[num4].rotation = 0f;
            Main.itemText[num4].position.X = newItem.position.X + newItem.width * 0.5f - vector3.X * 0.5f;
            Main.itemText[num4].position.Y = newItem.position.Y + newItem.height * 0.25f - vector3.Y * 0.5f;
            Main.itemText[num4].color = Color.White;
            if (newItem.rare == ItemRarityID.Blue)
            {
                Main.itemText[num4].color = new Color(150, 150, 255);
            }
            else if (newItem.rare == ItemRarityID.Green)
            {
                Main.itemText[num4].color = new Color(150, 255, 150);
            }
            else if (newItem.rare == ItemRarityID.Orange)
            {
                Main.itemText[num4].color = new Color(255, 200, 150);
            }
            else if (newItem.rare == ItemRarityID.LightRed)
            {
                Main.itemText[num4].color = new Color(255, 150, 150);
            }
            else if (newItem.rare == ItemRarityID.Pink)
            {
                Main.itemText[num4].color = new Color(255, 150, 255);
            }
            else if (newItem.rare == -11)
            {
                Main.itemText[num4].color = new Color(255, 175, 0);
            }
            else if (newItem.rare == -1)
            {
                Main.itemText[num4].color = new Color(130, 130, 130);
            }
            else if (newItem.rare == ItemRarityID.LightPurple)
            {
                Main.itemText[num4].color = new Color(210, 160, 255);
            }
            else if (newItem.rare == ItemRarityID.Lime)
            {
                Main.itemText[num4].color = new Color(150, 255, 10);
            }
            else if (newItem.rare == ItemRarityID.Yellow)
            {
                Main.itemText[num4].color = new Color(255, 255, 10);
            }
            else if (newItem.rare == ItemRarityID.Cyan)
            {
                Main.itemText[num4].color = new Color(5, 200, 255);
            }
            else if (newItem.rare == ItemRarityID.Red)
            {
                Main.itemText[num4].color = new Color(255, 40, 100);
            }
            else if (newItem.rare == ItemRarityID.Purple)
            {
                Main.itemText[num4].color = new Color(180, 40, 255);
            }
            else if (newItem.rare > ItemRarityID.Purple)
            {
                Main.itemText[num4].color = ModRarity.GetRarity(newItem.rare).RarityColor();
            }
            Main.itemText[num4].expert = newItem.expert;
            Main.itemText[num4].name = newItem.AffixName();
            Main.itemText[num4].stack = stack;
            Main.itemText[num4].velocity.Y = -7f;
            Main.itemText[num4].lifeTime = 60;
            if (longText)
            {
                Main.itemText[num4].lifeTime *= 5;
            }
            Main.itemText[num4].coinValue = 0;
            Main.itemText[num4].coinText = (newItem.type >= ItemID.CopperCoin && newItem.type <= ItemID.PlatinumCoin);
        }

        //Method Swap that adds support for modded rarities with mouse text.
        private void Main_MouseText(On.Terraria.Main.orig_MouseText orig, Main self, string cursorText, int rare, byte diff, int hackedMouseX, int hackedMouseY, int hackedScreenWidth, int hackedScreenHeight)
        {
            orig(self, cursorText, rare, diff, hackedMouseX, hackedMouseY, hackedScreenWidth, hackedScreenHeight);
            _ = Color.White;

            int X = Main.mouseX + 10;
            int Y = Main.mouseY + 10;

            if (hackedMouseX != -1 && hackedMouseY != -1)
            {
                X = hackedMouseX + 10;
                Y = hackedMouseY + 10;
            }

            if (Main.ThickMouse)
            {
                X += 6;
                Y += 6;
            }

            Vector2 vector = Main.fontMouseText.MeasureString(cursorText);

            if (hackedScreenHeight != -1 && hackedScreenWidth != -1)
            {
                if (X + vector.X + 4f > hackedScreenWidth)
                {
                    X = (int)(hackedScreenWidth - vector.X - 4f);
                }
                if (Y + vector.Y + 4f > hackedScreenHeight)
                {
                    Y = (int)(hackedScreenHeight - vector.Y - 4f);
                }
            }
            else
            {
                if (X + vector.X + 4f > Main.screenWidth)
                {
                    X = (int)(Main.screenWidth - vector.X - 4f);
                }
                if (Y + vector.Y + 4f > Main.screenHeight)
                {
                    Y = (int)(Main.screenHeight - vector.Y - 4f);
                }
            }

            float num = Main.mouseTextColor / 255f;

            if (rare > ItemRarityID.Purple)
            {
                Color baseColor = ModRarity.GetRarity(rare).RarityColor() * num;
                ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, cursorText, new Vector2(X, Y), baseColor, 0f, Vector2.Zero, Vector2.One);
            }
        }
    }

    internal class RarityItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine name = tooltips.FirstOrDefault((TooltipLine t) => t.Name == "ItemName" && t.mod == "Terraria");

            if (item.rare > ItemRarityID.Purple)
            {
                name.overrideColor = ModRarity.GetRarity(item.rare).RarityColor();
            }
        }
    }
}