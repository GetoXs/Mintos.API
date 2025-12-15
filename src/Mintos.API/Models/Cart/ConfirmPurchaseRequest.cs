namespace Mintos.API;

/// <summary>
/// Request for confirming a purchase.
/// </summary>
public class ConfirmSharesPurchaseRequest
{
    /// <summary>
    /// ULID reference generated client-side.
    /// </summary>
    public string Reference { get; set; } = null!;
}

