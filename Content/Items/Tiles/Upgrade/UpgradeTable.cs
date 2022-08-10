using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace JustEnoughScythes.Content.Items.Tiles.Upgrade
{
	public class UpgradeTable : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			// Names
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Upgrade table");
			AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Table"));
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
			// The following 3 lines are needed if you decide to add more styles and stack them vertically
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleHorizontal = true;

			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addTile(Type);
		}
		public override void MouseOver(int i, int j) => Main.instance.MouseText("Upgrade");
		
		public override bool RightClick(int i, int j)
		{

			return true;
        }
	}	
}