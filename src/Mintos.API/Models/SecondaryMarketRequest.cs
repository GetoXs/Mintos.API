namespace Mintos.API;

public class SecondaryMarketRequest
{
    public int[]? PledgeTypeGroups { get; set; }
    public int[]? Countries { get; set; }
    public int[]? LenderCompanies { get; set; }
    public int[]? LenderGroups { get; set; }
    public string? MinLendingCompanyRiskScore { get; set; }
    public string? MaxLendingCompanyRiskScore { get; set; }
    public int? LateLoanExposure { get; set; }
    public int[]? ScheduleTypes { get; set; }
    public string? Isin { get; set; }
    public decimal? MinInterestRate { get; set; }
    public decimal? MaxInterestRate { get; set; }
    public int? TermFrom { get; set; }
    public int? TermTo { get; set; }
    public SortingOptions? Sorting { get; set; }
    public PaginationOptions? Pagination { get; set; }
    public decimal? MinAmount { get; set; }
    public string[]? Currencies { get; set; }
    public bool? IndirectInvestmentStructure { get; set; }
    public bool? ShowOnlyInvestedByCurrentInvestor { get; set; }
    public decimal? MinPremiumOrDiscount { get; set; }
    public decimal? MaxPremiumOrDiscount { get; set; }
    public decimal? MinYtm { get; set; }
    public decimal? MaxYtm { get; set; }
}

public class SortingOptions
{
    public string SortField { get; set; } = "weightedAverageYieldToMaturity";
    public string SortOrder { get; set; } = "DESC";
}

public class PaginationOptions
{
    public int MaxResults { get; set; } = 30;
    public int Page { get; set; } = 1;
}

