namespace Mintos.API;

/// <summary>
/// Response from confirming a purchase.
/// </summary>
public class ConfirmSharesPurchaseResponse
{
    public List<ConfirmSharesPurchaseItem>? SuccessfulItems { get; set; }
    public List<ConfirmSharesPurchaseFailedItem>? FailedItems { get; set; }
}

public class ConfirmSharesPurchaseItem
{
    public string? Id { get; set; }
    public MoneyAmount? InvestmentAmount { get; set; }
    public MoneyAmount? InvestedAmount { get; set; }
    public MoneyAmount? InvestedAmountWithPremiumOrDiscount { get; set; }
    public string? AssetType { get; set; }
    public decimal PremiumOrDiscount { get; set; }
}

public class ConfirmSharesPurchaseFailedItem
{
    public string? Id { get; set; }
    public string? Error { get; set; }
}

