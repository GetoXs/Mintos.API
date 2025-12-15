namespace Mintos.API;

/// <summary>
/// Response from GET cart/note-series-shares.
/// </summary>
public class CartSharesResponse
{
    public List<CartShareItem>? Items { get; set; }
    public object? Pagination { get; set; }
}

public class CartShareItem
{
    public string? Isin { get; set; }
    public string? ShareId { get; set; }
    public string? PledgeTypeGroup { get; set; }
    public int LenderCompanyId { get; set; }
    public string? LenderName { get; set; }
    public string? CountryCode { get; set; }
    public DateTime MaturityDate { get; set; }
    public decimal InterestRate { get; set; }
    public MoneyAmount? InvestmentAmount { get; set; }
    public MoneyAmount? InvestmentAmountWithPremiumOrDiscount { get; set; }
    public MoneyAmount? AvailableForInvestmentAmount { get; set; }
    public MoneyAmount? ShareAmount { get; set; }
    public MoneyAmount? SharePrice { get; set; }
    public decimal PremiumOrDiscount { get; set; }
    public string? WeightedAverageYieldToMaturity { get; set; }
    public LendingCompanyRiskScore? LendingCompanyRiskScore { get; set; }
    public string? ScheduleType { get; set; }
    public bool ManualInvestmentAllowed { get; set; }
    public string? AssetType { get; set; }
}

