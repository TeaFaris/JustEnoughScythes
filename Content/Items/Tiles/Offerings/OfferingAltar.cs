using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;
using JustEnoughScythes.Systems;
using JustEnoughScythes.Content.Items.Offerings;

namespace JustEnoughScythes.Content.Items.Tiles.Offerings
{
    public class OfferingAltar : ModTile
    {
        public override void SetStaticDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

			// Names
			AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Altar"));

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
			// The following 3 lines are needed if you decide to add more styles and stack them vertically
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleHorizontal = true;

			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addTile(Type);
		}
        public override void MouseOver(int i, int j) => Main.instance.MouseText("Make an offering...");
		public override bool RightClick(int i, int j)
        {
			JESPlayer JESPlayer = Main.LocalPlayer.GetModPlayer<JESPlayer>();
			List<int> Offerings = JESPlayer.Player.inventory.Select((x, i) => x.ModItem is Offering ? i : -1).Where(i => i != -1).ToList();
			if (Offerings.Count <= 0) return false;
			JESPlayer.UsedOfferings.Union(Offerings.Select(x => JESPlayer.Player.inventory[x]));

			new SoundPlayer().Play(SoundID.Zombie53);
			foreach (int Offering in Offerings)
				JESPlayer.Player.inventory[Offering] = Main.item[JESPlayer.Player.QuickSpawnItem(new EntitySource_Misc("From Altar"), ItemID.Coal)];
			return true;
        }
    }
}