using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

/// <summary>
/// POST user/note-series/investments/current and …/finished — filters for note-series positions.
/// Kept separate from <see cref="NoteSeriesSearchRequestBase"/> (e.g. <c>currency</c> vs <c>currencies</c>, nullable page size).
/// </summary>
public class CurrentNoteSeriesInvestmentsRequest
{
	public string[]? PledgeTypeGroups { get; set; }
	public int[]? Countries { get; set; }
	public int[]? LenderCompanies { get; set; }
	public int[]? LenderGroups { get; set; }
	public string? MinLendingCompanyRiskScore { get; set; }
	public string? MaxLendingCompanyRiskScore { get; set; }
	public string[]? LateLoanExposure { get; set; }
	public string[]? ScheduleTypes { get; set; }
	public string? Isin { get; set; }
	public decimal? MinInterestRate { get; set; }
	public decimal? MaxInterestRate { get; set; }
	public int? TermFrom { get; set; }
	public int? TermTo { get; set; }
	public SortingOptions? Sorting { get; set; }
	public CurrentNoteSeriesInvestmentsPagination? Pagination { get; set; }
	public decimal? MinAmount { get; set; }
	public int? Currency { get; set; }
	public string[]? LenderStatuses { get; set; }
	public bool? ListedForSale { get; set; }
	public DateTimeOffset? InvestmentDateFrom { get; set; }
	public DateTimeOffset? InvestmentDateTo { get; set; }
	public bool? HasPendingPayments { get; set; }
	public int[]? Strategies { get; set; }
	public bool? IncludeManualInvestments { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class CurrentNoteSeriesInvestmentsPagination
{
	public int? MaxResults { get; set; }
	public int Page { get; set; } = 1;
}
