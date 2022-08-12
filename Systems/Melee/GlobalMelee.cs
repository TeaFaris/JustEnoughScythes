using JustEnoughScythes.Systems.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;

namespace JustEnoughScythes.Systems.Melee
{
    public class GlobalMelee : CustomGlobalItem
    {
        private int StandardDamage { get; set; }
        private float StandardKnockback { get; set; }
        public override bool AltFunctionUse(Item item, Player player) => true;
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.GetModPlayer<JESPlayer>().IsBlocking)//Sets what happens on right click(special ability)
            {
                item.noUseGraphic = true;
                item.useStyle = ItemUseStyleID.None;
                item.shoot = ModContent.ProjectileType<BlockProjectile>();
                item.shootSpeed = 10;
            }
            player.HeldItem.SetDefaults(player.HeldItem.type);
            return true;
        }
    }
    public class BlockProjectile : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{Main.player[Projectile.owner].HeldItem.type}";
        public override void SetDefaults()
        {
            Projectile.width = TextureAssets.Item[Main.player[Projectile.owner].HeldItem.type].Value.Width;
            Projectile.height = TextureAssets.Item[Main.player[Projectile.owner].HeldItem.type].Value.Height;
            Projectile.aiStyle = 20;
        }
    }
}