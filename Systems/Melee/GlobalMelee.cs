using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace JustEnoughSickles.Systems.Melee
{
    public class GlobalMelee : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (player.GetModPlayer<JESPlayer>().IsBlocking)
                Projectile.NewProjectile(new EntitySource_ItemUse(player, item), player.position, Vector2.Zero, ModContent.ProjectileType<BlockProjectile>(), item.damage / 2, item.knockBack * 2, player.whoAmI);
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            hitbox = Rectangle.Empty;
        }
    }
    public class BlockProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 1;
        public override void SetDefaults()
        {
            Projectile.aiStyle = 20;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.soundDelay = int.MaxValue;
        }
    }
}