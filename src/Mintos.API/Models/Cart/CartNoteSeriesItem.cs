namespace Mintos.API;

/// <summary>
/// Row in GET cart/note-series; same shape as marketplace primary listing plus cart-specific fields.
/// </summary>
public class CartNoteSeriesItem : PrimaryMarketNoteSeriesItem
{
	public MoneyAmount? InvestmentAmount { get; set; }
	public string? FinalTermsUrl { get; set; }
}
