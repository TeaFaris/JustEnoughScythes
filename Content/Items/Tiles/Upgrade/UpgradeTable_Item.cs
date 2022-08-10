using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JustEnoughScythes.Content.Items.Tiles.Upgrade
{
	public class UpgradeTable_Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Using for upgrading your ranged weapons");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<UpgradeTable>());
			Item.value = 150;
			Item.maxStack = 99;
			Item.width = 12;
			Item.height = 30;
		}
	}
}
