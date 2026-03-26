using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

public class CurrentNoteSeriesInvestmentsResponse
{
	public List<CurrentNoteSeriesInvestmentItem>? Items { get; set; }
	public PaginationResult? Pagination { get; set; }
	public CurrentNoteSeriesInvestmentsExtraData? ExtraData { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class CurrentNoteSeriesInvestmentsExtraData
{
	public CurrentNoteSeriesInvestmentsTotals? Total { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class CurrentNoteSeriesInvestmentsTotals
{
	public MoneyAmount? ReceivedPayments { get; set; }
	public MoneyAmount? InvestedAmount { get; set; }
	public MoneyAmount? InitialAmount { get; set; }
}

[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class CurrentNoteSeriesInvestmentItem
{
	public string? InvestmentId { get; set; }
	public string? Isin { get; set; }
	public string? PledgeTypeGroup { get; set; }
	public LendingCompanyRiskScore? LendingCompanyRiskScore { get; set; }
	public int LenderCompanyId { get; set; }
	public decimal InterestRate { get; set; }
	public DateTime MaturityDate { get; set; }
	public DateTime PurchaseDate { get; set; }
	public MoneyAmount? InvestedAmount { get; set; }
	public MoneyAmount? InitialAmount { get; set; }
	public string? Origin { get; set; }
	public long? AutoInvestDefinitionId { get; set; }
	public DateTime? NextPaymentDate { get; set; }
	public MoneyAmount? NextPaymentAmount { get; set; }
	public int FinishedPaymentCount { get; set; }
	public MoneyAmount? ReceivedPayments { get; set; }
	public MoneyAmount? AmountInSecondaryMarket { get; set; }
	public bool IsInvestmentBelowSellingMinimum { get; set; }
	public bool IsShareBelowListingMinimum { get; set; }
	public DateTime? ListedForSaleAt { get; set; }
	public bool NotGeneratingInterest { get; set; }
	public decimal? PremiumDiscountInSecondaryMarket { get; set; }
	public MoneyAmount? PriceInSecondaryMarket { get; set; }
	public MoneyAmount? PendingPaymentAmount { get; set; }
	public MoneyAmount? InRecoveryAmount { get; set; }
	public string? LenderName { get; set; }
	public int CountryId { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
