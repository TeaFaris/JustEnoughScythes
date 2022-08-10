using JustEnoughScythes.Systems.Melee;
using JustEnoughScythes.Utils;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustEnoughScythes.Systems.Items
{
    public class CustomGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        private bool IsChangedStyle { get; set; } = false;
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Main.LocalPlayer.GetWeaponArmorPenetration(item) <= 0)
                return;
            tooltips.Insert(2, new TooltipLine(Mod, "Penetration", $"{Main.LocalPlayer.GetWeaponArmorPenetration(item)} armor penetration"));
        }
        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            if (item.holdStyle == ItemHoldStyleID.None)
            {
                new Switch<int>(item.DamageType.Type)
                    .Case(DamageClass.Melee.Type, () => item.holdStyle = ItemHoldStyleID.HoldGuitar)
                    .Case(DamageClass.Magic.Type, () => item.holdStyle = ItemHoldStyleID.HoldFront)
                    .Case(DamageClass.MeleeNoSpeed.Type, () => item.holdStyle = ItemHoldStyleID.HoldFront)
                    .Case(DamageClass.Ranged.Type, () => item.holdStyle = ItemHoldStyleID.HoldFront);
                IsChangedStyle = true;
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
                        new Switch<int>(item.useAmmo)
                            .Case(AmmoID.Arrow, () =>
                            {
                                new Switch<int>(item.type)
                                    .Case(new int[] { ItemID.BeesKnees, ItemID.Tsunami, ItemID.PulseBow }, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 23f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 12f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 16f;
                                    })
                                    .Case(ItemID.FairyQueenRangedItem, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 35f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 12f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 16f;
                                    })
                                    .Case(new int[] { ItemID.CobaltRepeater, ItemID.AdamantiteRepeater, ItemID.HallowedRepeater, ItemID.MythrilRepeater, ItemID.OrichalcumRepeater, ItemID.PalladiumRepeater, ItemID.TitaniumRepeater, ItemID.ChlorophyteShotbow }, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 12f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 26f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 30f;
                                    })
                                    .Default(() =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 16f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 6f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 10f;
                                    });
                            })
                            .Case(AmmoID.Bullet, () =>
                            {
                                new Switch<int>(item.type)
                                    .Case(new int[] { ItemID.Handgun, ItemID.PhoenixBlaster, ItemID.FlintlockPistol, ItemID.Revolver, ItemID.TheUndertaker, ItemID.TacticalShotgun, ItemID.Xenopopper, ItemID.Uzi }, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 16f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 20f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 22f;
                                    })
                                    .Case(new int[] { ItemID.Shotgun, ItemID.Boomstick }, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 8f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 20f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 22f;
                                    })
                                    .Default(() =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 14f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 28f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 32f;
                                    });
                            })
                            .Case(AmmoID.Rocket, () =>
                            {
                                new Switch<int>(item.type)
                                    .Case(ItemID.FireworksLauncher, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 12f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 16f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 18f;
                                    })
                                    .Case(ItemID.ElectrosphereLauncher, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 12f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 34f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 38f;
                                    })
                                    .Default(() =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 12f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 26f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 30f;
                                    });
                            })
                            .Case(AmmoID.Dart, () =>
                            {
                                new Switch<int>(item.type)
                                    .Case(new int[] { ItemID.DartPistol, ItemID.DartRifle }, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 14f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 25f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 29f;
                                    })
                                    .Default(() =>
                                    {
                                        player.itemLocation.Y = player.Center.Y + 4f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 20f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 22f;
                                    });
                            })
                            .Case(new int[] { AmmoID.Snowball, AmmoID.FallenStar }, () =>
                            {
                                player.itemLocation.Y = player.Center.Y - 12f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 26f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 30f;
                            })
                            .Case(0, () =>
                            {
                                new Switch<int>(item.type)
                                    .Case(ItemID.Toxikarp, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 2f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 4f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X + 4f;
                                    })
                                    .Case(ItemID.PainterPaintballGun, () =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 9f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 12f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 16f;
                                    })
                                    .Default(() =>
                                    {
                                        player.itemLocation.Y = player.Center.Y - 12f;
                                        if (player.direction < 0)
                                            player.itemLocation.X = player.Center.X - 20f;
                                        if (player.direction > 0)
                                            player.itemLocation.X = player.Center.X - 24f;
                                    });
                            })
                            .Case(AmmoID.CandyCorn, () =>
                            {
                                player.itemLocation.Y = player.Center.Y - 20f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 20f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 22f;
                            })
                            .Default(() =>
                            {
                                player.itemLocation.Y = player.Center.Y - 10f;
                                if (player.direction < 0)
                                    player.itemLocation.X = player.Center.X - 20f;
                                if (player.direction > 0)
                                    player.itemLocation.X = player.Center.X - 22f;
                            });
                    });
            }
        }
    }
}
