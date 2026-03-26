using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

/// <summary>
/// Shared filter body for POST note-series marketplace endpoints (primary / secondary).
/// Unknown JSON properties round-trip via <see cref="ExtensionData"/> for forward compatibility.
/// </summary>
public abstract class NoteSeriesSearchRequestBase
{
	public string[]? PledgeTypeGroups { get; set; }
	public int[]? Countries { get; set; }
	public int[]? LenderCompanies { get; set; }
	public int[]? LenderGroups { get; set; }
	public string? MinLendingCompanyRiskScore { get; set; }
	public string? MaxLendingCompanyRiskScore { get; set; }
	public string[]? LateLoanExposure { get; set; }
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

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
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
