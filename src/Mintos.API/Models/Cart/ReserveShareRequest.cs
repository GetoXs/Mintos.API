namespace Mintos.API;

/// <summary>
/// Request item for reserving a share in the cart.
/// </summary>
public class ReserveShareRequestItem
{
    /// <summary>
    /// Share ID from the secondary market listing.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Price as string (e.g. "3.1").
    /// </summary>
    public string Price { get; set; } = null!;
}

