using JustEnoughSickles.Systems;
using JustEnoughSickles.Systems.NPCs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace JustEnoughSickles.Content.NPCs.Souls
{
    public abstract class SoulMob : HandledNPC
    {
        public SoulType SoulType { get; set; }
        public Color MainColor { get; set; }
        public float MaxVelocity { get; set; } = 4f;
        protected Vector2 EndPosition { get; set; }
        protected bool WentToEndPosition { get; set; } = false;
        public override void SetDefaults()
        {
            NPC.width = 22;
            NPC.height = 22;
            NPC.damage = 1;
            NPC.lifeMax = 1;
            NPC.immortal = true;
            NPC.aiStyle = -1;
            NPC.knockBackResist = float.MinValue;
            MaxVelocity = 4f;
        }
        public override void OnSpawn(IEntitySource source) => EndPosition = new Vector2(NPC.position.X + Main.rand.Next(-20, 20), NPC.position.Y + Main.rand.Next(-40, 40));
        public override void AI()
        {
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            Dust Dust = Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RainbowMk2, NPC.velocity.X, NPC.velocity.Y, newColor: MainColor)];
            Dust.noGravity = true;
            Dust.velocity *= 0.1f;

            if (Math.Sqrt(Math.Pow(EndPosition.X - NPC.position.X, 2) + Math.Pow(EndPosition.Y - NPC.position.Y, 2)) > 16 && !WentToEndPosition)
            {
                GotoPosition(EndPosition);
                return;
            }
            else if(!WentToEndPosition)
            {
                NPC.velocity = Vector2.Zero;
                WentToEndPosition = true;
            }
            

            if (Target == null)
            {
                NPC.TargetClosest(true);
                Target = Main.player[NPC.target];
            }
            if (Target.dead)
                return;

            NPC.target = Target.whoAmI;
            Vector2 TargetPos = Target.position;

            if (Math.Sqrt(Math.Pow(TargetPos.X - NPC.position.X, 2) + Math.Pow(TargetPos.Y - NPC.position.Y, 2)) > Target.GetModPlayer<JESPlayer>().SoulPickupRange * 16)
            {
                NPC.velocity = Vector2.Zero;
                return;
            }
            GotoPosition(TargetPos);

            void GotoPosition(Vector2 Position)
            {
                if (Position.X < NPC.position.X && NPC.velocity.X > -MaxVelocity / 2f)
                    NPC.velocity.X -= MaxVelocity / 10f;
                if (Position.X > NPC.position.X && NPC.velocity.X < MaxVelocity / 2f)
                    NPC.velocity.X += MaxVelocity / 10f;
                if (Position.Y < NPC.position.Y && NPC.velocity.Y > -MaxVelocity / 2f)
                    NPC.velocity.Y -= MaxVelocity / 10f;
                if (Position.Y > NPC.position.Y && NPC.velocity.Y < MaxVelocity / 2f)
                    NPC.velocity.Y += MaxVelocity / 10f;
            }

        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.05000000596046448;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            NPC.frame.Y = (int)NPC.frameCounter * frameHeight;
        }
        public override bool CheckActive() => false;
        public override void SetStaticDefaults() => Main.npcFrameCount[NPC.type] = 4;
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit) => target.immune = true;
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.GetModPlayer<JESPlayer>().SoulsContainer[SoulType] += 1;
            NPC.immortal = false;
            NPC.life = -1;
            target.immune = false;
        }
        public override bool? CanHitNPC(NPC target) => false;
    }
    public enum SoulType
    {
        Inferno,
        Frost,
        Shadow,
        Light
    }
}
