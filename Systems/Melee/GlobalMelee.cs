using JustEnoughScythes.Systems.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using JustEnoughScythes.Utils.IDs;
using Microsoft.Xna.Framework;

namespace JustEnoughScythes.Systems.Melee
{
    public class GlobalMelee : CustomGlobalItem
    {
        public override bool AltFunctionUse(Item item, Player player) => true;
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.GetModPlayer<JESPlayer>().IsBlocking)//Sets what happens on right click(special ability)
                item.shoot = JESProjectileID.BlockProjectile;

            return true;
        }
        public override bool? UseItem(Item item, Player player)
        {
            item.SetDefaults(item.type);
            return true;
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            if (player.GetModPlayer<JESPlayer>().IsBlocking)
                hitbox = Rectangle.Empty;
        }
    }
    public class BlockProjectile : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.FromNetId((short)Main.player[Projectile.owner].HeldItem.netID)}";
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.aiStyle = ProjAIStyleID.Drill;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 1000;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            if (!Main.player[Projectile.owner].GetModPlayer<JESPlayer>().IsBlocking)
                Projectile.Kill();
        }
    }
}