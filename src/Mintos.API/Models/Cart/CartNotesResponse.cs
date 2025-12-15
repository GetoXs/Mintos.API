namespace Mintos.API;

/// <summary>
/// Response from GET cart/note-series (primary market cart).
/// </summary>
public class CartNotesResponse
{
    public List<object>? Items { get; set; }
    public object? Pagination { get; set; }
}

