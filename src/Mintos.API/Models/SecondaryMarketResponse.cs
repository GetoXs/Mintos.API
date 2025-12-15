using System.Globalization;

namespace Mintos.API;

public class SecondaryMarketResponse
{
    public List<SecondaryMarketNote>? Items { get; set; }
    public PaginationResult? Pagination { get; set; }
}

public class PaginationResult
{
    public int Page { get; set; }
    public bool HasNextPage { get; set; }
    public int MaxResults { get; set; }
    public int Total { get; set; }
}

public class SecondaryMarketNote
{
    public string? Isin { get; set; }
    public string? ShareId { get; set; }
    public string? PledgeTypeGroup { get; set; }
    public int LenderCompanyId { get; set; }
    public string? LenderName { get; set; }
    public string? CountryCode { get; set; }
    public DateTime MaturityDate { get; set; }
    public decimal InterestRate { get; set; }
    public MoneyAmount? AvailableForInvestmentAmount { get; set; }
    public MoneyAmount? ShareAmount { get; set; }
    public MoneyAmount? SharePrice { get; set; }
    public decimal PremiumOrDiscount { get; set; }
    public string? WeightedAverageYieldToMaturity { get; set; }
    public LendingCompanyRiskScore? LendingCompanyRiskScore { get; set; }
    public decimal LateLoanExposure { get; set; }
    public string? ScheduleType { get; set; }
    public bool ManualInvestmentAllowed { get; set; }
}

public class MoneyAmount
{
    public string? Currency { get; set; }
    public string? Amount { get; set; }

    public decimal AmountDecimal => decimal.TryParse(Amount, NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : 0;
}

public class LendingCompanyRiskScore
{
    public string? Score { get; set; }

    public decimal ScoreDecimal => decimal.TryParse(Score, NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : 0;
}

