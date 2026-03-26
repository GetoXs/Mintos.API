namespace Mintos.API;

/// <summary>
/// One line in the body of POST cart/note-series (add primary note series to cart).
/// </summary>
public class CartNoteSeriesAddItem
{
	public string Amount { get; set; } = "";
	public string Isin { get; set; } = "";
}
