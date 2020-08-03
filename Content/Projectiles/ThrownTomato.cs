using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace TomatoLib.Content.Projectiles
{
    public class ThrownTomato : ModProjectile
    {
        public override string Texture => "TomatoLib/Content/Items/Tomato";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tomato");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 26;
            projectile.alpha = 0;
            projectile.timeLeft = 1200;
            projectile.penetrate = 1;
            projectile.scale = 0.8f;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;

            if (projectile.ai[0] >= 10f)
            {
                projectile.velocity.Y += 0.2f;
                projectile.velocity.X *= 0.98f; ;
            }

            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 76, newColor: Color.Red);
                Main.dust[dust].noGravity = true;
                Dust dust2 = Main.dust[dust];
                Dust dust3 = dust2;
                dust3.velocity -= projectile.oldVelocity * 0.25f;
            }

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(3, 1), projectile.position);
        }
    }
}
