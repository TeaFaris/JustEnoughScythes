using JustEnoughSickles.Systems.Items;
using JustEnoughSickles.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustEnoughSickles.Systems.Melee
{
    public class GlobalMelee : CustomGlobalItem
    {
        public override bool InstancePerEntity => true;
        private bool IsChangedStyle { get; set; } = false;
        private int StandardDamage { get; set; }
        private float StandardKnockback { get; set; }
        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            if(item.holdStyle == ItemHoldStyleID.None)
            {
                new Switch<int>(item.DamageType.Type)
                    .Case(DamageClass.Melee.Type, () => item.holdStyle = ItemHoldStyleID.HoldGuitar)
                    .Case(DamageClass.Magic.Type, () => item.holdStyle = ItemHoldStyleID.HoldFront)
                    .Case(DamageClass.MeleeNoSpeed.Type, () => item.holdStyle = ItemHoldStyleID.HoldFront);
                IsChangedStyle = true;
            }
                
        }
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
        public override void HoldStyle(Item item, Player player, Rectangle heldItemFrame)
        {
            if (item.handOnSlot < 0 && item.GetGlobalItem<GlobalMelee>().IsChangedStyle)
            {
                new Switch<int>(item.DamageType.Type)
                    .Case(DamageClass.Melee.Type, () =>
                    {
                        player.itemLocation.Y = player.Center.Y + 14f;
                        if (player.direction < 0)
                            player.itemLocation.X = player.Center.X + 4f;
                        if (player.direction > 0)
                            player.itemLocation.X = player.Center.X - 4f;
                    })
                    .Case(DamageClass.Magic.Type, () =>
                    {
                        //float LeftDirOffset = 2f / 3f;
                        //float RightDirOffset = 5f / 6f;

                        //player.itemLocation.Y = player.Center.Y - 12f;
                        //if (player.direction < 0)
                        //    player.itemLocation.X = player.Center.X - item.width * LeftDirOffset;
                        //if (player.direction > 0)
                        //    player.itemLocation.X = player.Center.X - item.width * RightDirOffset;

                        new Switch<Vector2>(item.Size)
                            .Case(new Vector2(26, 28), () => // IceRod and etc.
                            {
                                player.itemLocation.Y = player.Center.Y + 10f;
                                if (player.direction < 0)
                                {
                                    player.itemRotation = 0;
                                    player.itemLocation.X = player.Center.X - 4f;
                                }
                                if (player.direction > 0)
                                {
                                    player.itemRotation = 0;
                                    player.itemLocation.X = player.Center.X + 4f;
                                }
                            })
                            .Case(new Vector2[] { new Vector2(24, 18), new Vector2(24, 28) }, () => // CosmoGun, HeatGun
                            {
                                player.itemLocation.Y = player.Center.Y - 12f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 16f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 20f;
                            })
                            .Default(() =>
                            {
                                player.itemLocation.Y = player.Center.Y;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 5.5f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X + 5.5f;
                            });

                        new Switch<int>(item.type)
                            .Case(new int[] { ItemID.ZapinatorGray, ItemID.ZapinatorOrange, ItemID.BeeGun, ItemID.WaspGun, ItemID.RainbowGun, ItemID.BubbleGun, ItemID.AquaScepter }, () =>
                            {
                                player.itemLocation.Y = player.Center.Y - 12f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 20f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 26f;
                            })
                            .Case(new int[] { ItemID.DemonScythe, ItemID.RazorbladeTyphoon, ItemID.WaterBolt, ItemID.BookofSkulls, ItemID.CrystalStorm, ItemID.CursedFlame, ItemID.GoldenShower, ItemID.MagnetSphere, ItemID.LunarFlareBook }, () =>
                            {
                                player.itemLocation.Y = player.Center.Y - 16f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 12f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 16f;
                            });

                    })
                    .Case(DamageClass.MeleeNoSpeed.Type, () =>
                    {
                        player.itemLocation.Y = player.Center.Y - 20f;
                        if (player.direction < 0)
                            player.itemLocation.X = player.Center.X - 28f;
                        if (player.direction > 0)
                            player.itemLocation.X = player.Center.X - 32f;
                    })
                    .Case(DamageClass.Ranged.Type, () =>
                    {
                        player.itemLocation.Y = player.Center.Y;
                        if (player.direction < 0)
                            player.itemLocation.X = player.Center.X;
                        if (player.direction > 0)
                            player.itemLocation.X = player.Center.X;
                    });
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