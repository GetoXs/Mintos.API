namespace Mintos.API;

/// <summary>
/// Response from GET cart/note-series (primary market cart).
/// </summary>
public class CartNotesResponse
{
	public List<CartNoteSeriesItem>? Items { get; set; }
	public PaginationResult? Pagination { get; set; }
}
