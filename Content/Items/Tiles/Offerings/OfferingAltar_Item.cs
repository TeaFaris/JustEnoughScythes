using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JustEnoughSickles.Content.Items.Tiles.Offerings
{
	public class OfferingAltarItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a... Wait a minute, how did you get that item. Oh no... You are cheating! Quick, delete this item, you are not supposed to get this item!");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<OfferingAltar>());
			Item.value = 150;
			Item.maxStack = 99;
			Item.width = 12;
			Item.height = 30;
		}
	}
}
