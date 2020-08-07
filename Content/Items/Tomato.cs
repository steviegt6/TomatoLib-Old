using Terraria.ID;
using Terraria.ModLoader;
using TomatoLib.Content.Projectiles;
using TomatoLib.Content.Rarities;
using TomatoLib.Core;

namespace TomatoLib.Content.Items
{
    internal class Tomato : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Booooo! That sucked!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.damage = 5;
            item.value = 0;
            item.useTime = item.useAnimation = 10;
            item.rare = TomatoLoader.RarityType<TomatoRarity>();
            item.maxStack= 99;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<ThrownTomato>();
            item.shootSpeed = 8f;
        }
    }
}
