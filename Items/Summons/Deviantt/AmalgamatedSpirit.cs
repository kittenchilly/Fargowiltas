using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AmalgamatedSpirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amalgamated Spirit");
            Tooltip.SetDefault("Summons the skeleton mages\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("SpawnProj");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, Main.rand.Next(2) == 0 ? NPCID.Necromancer : NPCID.NecromancerArmored);

            pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, Main.rand.Next(2) == 0 ? NPCID.DiabolistRed : NPCID.DiabolistWhite);

            pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, Main.rand.Next(2) == 0 ? NPCID.RaggedCaster : NPCID.RaggedCasterOpenCoat);

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}