using JustEnoughScythes.Systems.Items;
using JustEnoughScythes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustEnoughScythes.Systems.Melee
{
    public class GlobalMelee : CustomGlobalItem
    {
        private int StandardDamage { get; set; }
        private float StandardKnockback { get; set; }
        public override void HoldItem(Item item, Player player)
        {
            JESPlayer JESPlayer = player.GetModPlayer<JESPlayer>();
            JESPlayer.IsBlocking = item.DamageType.Type == DamageClass.Melee.Type && Main.mouseRight;
            if (JESPlayer.IsBlocking)
            {
                //Projectile.NewProjectile(new EntitySource_ItemUse(player, item), player.position, Vector2.Zero, ModContent.ProjectileType<BlockProjectile>(), 0, 0, player.whoAmI);

            }
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            if (player.GetModPlayer<JESPlayer>().IsBlocking)
            {
                hitbox = new Rectangle((int)player.position.X + 16, (int)player.position.Y - 4, 16, hitbox.Height);
            }
        }
    }
    public class BlockProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 1;
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.HeldProjectile;
            Projectile.friendly = true;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
        }
        public override bool PreDraw(ref Color lightColor) => false;
        public override void AI() { }
    }
}