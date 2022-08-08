using JustEnoughSickles.Systems.Configs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace JustEnoughSickles.Content.UI.SoulsUI
{
    public sealed class UISystem : ModSystem
    {
        private UserInterface StaticUI { get; set; }
        private SoulsUI SoulsUI { get; set; }
        private UserInterface DynamicUI { get; set; }
        private SoulBarsUI SoulBarsUI { get; set; }
        public override void Load()
        {
            SoulsUI = new SoulsUI();
            SoulsUI.Activate();
            StaticUI = new UserInterface();
            StaticUI.SetState(SoulsUI);
            SoulBarsUI = new SoulBarsUI();
            SoulBarsUI.Activate();
            DynamicUI = new UserInterface();
            DynamicUI.SetState(SoulBarsUI);
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (Main.gameMenu)
                return;

            StaticUI.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Insert(0, new LegacyGameInterfaceLayer("Dynamic UI", DrawDynamicUI, InterfaceScaleType.Game));
            layers.Insert(1, new LegacyGameInterfaceLayer("Static UI", DrawStaticUI, InterfaceScaleType.Game));
        }
        private bool DrawStaticUI()
        {
            if (Main.gameMenu || !ModContent.GetInstance<Config>().EnableUI)
                return true;
            if (SoulBarsUI.SoulBars[0].TopBar != ModContent.GetInstance<Config>().UIYPos + 38f || SoulBarsUI.SoulBars[0].LeftBar != ModContent.GetInstance<Config>().UIXPos + 6f)
                ModContent.GetInstance<UISystem>().SoulBarsUI.OnInitialize();

            StaticUI.Draw(Main.spriteBatch, new GameTime());
            return true;
        }
        private bool DrawDynamicUI()
        {
            if (Main.gameMenu || !ModContent.GetInstance<Config>().EnableUI)
                return true;
            if (SoulsUI.Top.Percent != ModContent.GetInstance<Config>().UIYPos / 1920f || SoulsUI.Left.Percent != ModContent.GetInstance<Config>().UIXPos / 1920f)
                ModContent.GetInstance<UISystem>().SoulsUI.OnInitialize();

            DynamicUI.Draw(Main.spriteBatch, new GameTime());
            return true;
        }
    }
}
