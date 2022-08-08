using JustEnoughSickles.Content.NPCs.Souls;
using JustEnoughSickles.Systems;
using JustEnoughSickles.Systems.Configs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace JustEnoughSickles.Content.UI.SoulsUI
{
	public sealed class SoulsUI : UIState
	{
		private UIImage SoulCounter { get; set; }
		public override void OnInitialize()
        {
			if (SoulCounter != null)
				SoulCounter.Remove();
			SoulCounter = new UIImage(ModContent.Request<Texture2D>("JustEnoughSickles/Content/UI/SoulsUI/Assets/UI_Souls"));
			SoulCounter.Top.Set(0f, ModContent.GetInstance<Config>().UIYPos / 1920f);
			SoulCounter.Left.Set(0f, ModContent.GetInstance<Config>().UIXPos / 1920f);
			SoulCounter.Width.Set(30 / Main.PendingResolutionWidth, 0f);
			SoulCounter.Height.Set(139.5f / Main.PendingResolutionHeight, 0f);
			Append(SoulCounter);
		}
    }
	public sealed class SoulBarsUI : UIState
    {
		public SoulBar[] SoulBars;
		public override void OnInitialize()
        {
			if (SoulBars != null)
				new List<SoulBar>(SoulBars).ForEach(x => x.Image.Remove());
			SoulBars = new SoulBar[Enum.GetValues<SoulType>().Length];
			Player Player = Main.LocalPlayer;
			for (int i = 0; i < SoulBars.Length; i++)
				SoulBars[i] = new SoulBar(ModContent.GetInstance<Config>().UIYPos, ModContent.GetInstance<Config>().UIXPos, Player.whoAmI, (SoulType)i);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			if (!ModContent.GetInstance<Config>().EnableUI)
				return;
			for (int i = 0; i < SoulBars.Length; i++)
				Append(SoulBars[i].Update(i));
			Recalculate();
			base.Draw(spriteBatch);
		}
	}
	public sealed class SoulBar : UIElement 
	{
		private int Player { get; set; }
		private SoulType Type { get; set; }
		private Asset<Texture2D> Texture { get; set; }
		public float TopBar { get; set; }
		public float LeftBar { get; set; }
		public UIImageFramed Image { get; set; }
		private new float Height => SoulsCount / (float)ReaperPlayer.MaxSouls * Texture.Value.Height;
		private float ActualHeight { get; set; } = 0;
		private float Counter { get; set; }
		private JESPlayer ReaperPlayer => Main.player[Player].GetModPlayer<JESPlayer>();
		public uint SoulsCount => ReaperPlayer.SoulsContainer[Type];
		public SoulBar(float TopPixel, float LeftPixel, int Player, SoulType Type)
        {
			Texture = ModContent.Request<Texture2D>($"JustEnoughSickles/Content/UI/SoulsUI/Assets/UI_{Type}_Bar");
			this.Type = Type;
			this.Player = Player;
			TopBar = TopPixel + 38f;
			LeftBar = LeftPixel + 6f;
        }
		public UIImageFramed Update(int i)
        {
			Image?.Remove();

			float Offset;
			for (Offset = 0; -Math.Pow(Offset, 2) + Height >= 0; Offset += 0.01f) ;

			if (ActualHeight < Height && Height > 0 && ActualHeight >= 0)
				ActualHeight += (float)-Math.Pow(Counter - Offset, 2) + Height + 1f;
			else if (ActualHeight < 0 || Height == 0)
			{
				ActualHeight = 0;
				Counter = 0;
			}
			else
				Counter = 0;
				
			Image = new UIImageFramed(Texture, new Rectangle(0, 0, Texture.Value.Width, (int)ActualHeight));
			Image.Top.Set(0f, TopBar / 1920f + 1920f / Main.PendingResolutionHeight * 5f / 1920f);
			Image.Left.Set(0f, LeftBar / 1920f + 1920f / Main.PendingResolutionWidth * 33f / 1920f * i);
			Image.Width.Set(0f, (float)Texture.Value.Width / Main.PendingResolutionWidth);
			Image.Height.Set(0f, (float)Texture.Value.Height / Main.PendingResolutionHeight);

			if (Main.mouseX / (float)Main.PendingResolutionWidth > (LeftBar / 1920f + 1920f / Main.PendingResolutionWidth * 37f / 1920f * i) + 122f / 1920f
				&& Main.mouseX / (float)Main.PendingResolutionWidth < (LeftBar / 1920f + 1920f / Main.PendingResolutionWidth * 37f / 1920f * i + Image.Width.Percent) + 122f / 1920f
				&& Main.mouseY / (float)Main.PendingResolutionHeight > TopBar / 1920f + 1920f / Main.PendingResolutionHeight * 5f / 1920f
				&& Main.mouseY / (float)Main.PendingResolutionHeight < TopBar / 1920f + 1920f / Main.PendingResolutionHeight * 5f / 1920f + Image.Height.Percent)
				Main.instance.MouseText($"{SoulsCount} / {ReaperPlayer.MaxSouls}");

			Counter += 0.01f;
			return Image;
		}
    }
}
