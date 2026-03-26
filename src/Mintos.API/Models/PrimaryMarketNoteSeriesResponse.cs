using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

public class PrimaryMarketNoteSeriesResponse
{
	public List<PrimaryMarketNoteSeriesItem>? Items { get; set; }
	public PaginationResult? Pagination { get; set; }
}

/// <summary>
/// One primary-market note series row. Mintos may add fields; unmapped JSON is preserved in <see cref="ExtensionData"/>.
/// </summary>
public class PrimaryMarketNoteSeriesItem
{
	public string? Isin { get; set; }
	/// <summary>Primary market listing page for this ISIN (locale fixed to en).</summary>
	public string? Url => Isin != null ? $"https://www.mintos.com/en/set-of-notes/{Isin}" : null;
	public string? PledgeTypeGroup { get; set; }
	public int LenderCompanyId { get; set; }
	public LendingCompanyRiskScore? LendingCompanyRiskScore { get; set; }
	public string? CountryCode { get; set; }
	public DateTime MaturityDate { get; set; }
	public DateTime InitialMaturityDate { get; set; }
	public DateTime NoteListedAt { get; set; }
	public MoneyAmount? NominalAmount { get; set; }
	public MoneyAmount? RemainingAmount { get; set; }
	public decimal InterestRate { get; set; }
	public MoneyAmount? AvailableForInvestmentAmount { get; set; }
	public MoneyAmount? NotePrice { get; set; }
	public bool HasLatePaymentInterest { get; set; }
	public int NoteIssuer { get; set; }
	public string? LenderGroupGuarantee { get; set; }
	public string? ScheduleType { get; set; }
	public decimal LateLoanExposure { get; set; }
	public int FinishedPaymentCount { get; set; }
	public bool IsFinished { get; set; }
	public MoneyAmount? InvestorsInvestedAmount { get; set; }
	public string? OriginalCreditCurrencyAbbreviation { get; set; }
	public bool ManualInvestmentAllowed { get; set; }
	public DateTime? CutOffDate { get; set; }
	public string? BaseProspectus { get; set; }
	public bool NewProspectusNotification { get; set; }
	public string? AssetType { get; set; }
	public DateTime? DtStart { get; set; }
	public string? LenderName { get; set; }
	public string? BaseProspectusLink { get; set; }
	public string? BondType { get; set; }
	public string? Industry { get; set; }
	public string? InterestPaymentType { get; set; }
	public string? InterestRateType { get; set; }
	public string? FloatingInterestRate { get; set; }
	public int? EuriborMonthCount { get; set; }
	public string? AdditionalInformationUrl { get; set; }
	public string? CreditScoreUrl { get; set; }
	public string? CreditRiskScore { get; set; }
	public decimal? YieldToMaturity { get; set; }
	public bool? IsPaymentDelayWarningEnabled { get; set; }
	public string? PaymentDelayWarningTranslationKey { get; set; }
	public string? PaymentDelayWarningUrl { get; set; }
	public string? RealEstateName { get; set; }
	public string? RealEstatePicture { get; set; }
	public bool HasPendingPayments { get; set; }
	public decimal? ExpectedAnnualAppreciation { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
