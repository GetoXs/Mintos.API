using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

public class FinishedNoteSeriesInvestmentsResponse
{
	public List<FinishedNoteSeriesInvestmentItem>? Items { get; set; }
	public PaginationResult? Pagination { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Row from POST user/note-series/investments/finished (repaid / closed positions).
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class FinishedNoteSeriesInvestmentItem
{
	public string? Isin { get; set; }
	public string? PledgeTypeGroup { get; set; }
	public LendingCompanyRiskScore? LendingCompanyRiskScore { get; set; }
	public int LenderCompanyId { get; set; }
	public decimal InterestRate { get; set; }
	public DateTime MaturityDate { get; set; }
	public DateTime PurchaseDate { get; set; }
	public MoneyAmount? InitialAmount { get; set; }
	public string? Origin { get; set; }
	/// <summary>0 when not from an automated strategy.</summary>
	public long AutoInvestDefinitionId { get; set; }
	public MoneyAmount? ReceivedPayments { get; set; }
	public DateTime FinishedAt { get; set; }
	public MoneyAmount? PendingPaymentAmount { get; set; }
	public MoneyAmount? InRecoveryAmount { get; set; }
	public string? LenderName { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
