using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

public class UserCurrencyOverviewResponse
{
	public UserOverviewTotal? Total { get; set; }
	public UserOverviewLoansLike? Loans { get; set; }
	public UserOverviewLoansLike? Bonds { get; set; }
	public UserOverviewLoansLike? RealEstate { get; set; }
	public UserOverviewEtf? Etf { get; set; }
	public UserOverviewSmartCash? SmartCash { get; set; }
	public UserOverviewLoansLike? Fundraising { get; set; }
	public UserOverviewValuatedAsset? CryptoEtp { get; set; }
	public UserOverviewValuatedAsset? SingleStock { get; set; }
	public UserOverviewValuatedAsset? SingleEtf { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class UserOverviewTotal
{
	public string? Value { get; set; }
	public string? Available { get; set; }
	public string? Reserved { get; set; }
	public string? Profit { get; set; }
	public string? UnrealizedProfit { get; set; }
	public string? KeepUninvested { get; set; }
	public string? PendingWithdrawal { get; set; }
	public string? AssetXCash { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class UserOverviewLoansLike
{
	public string? Value { get; set; }
	public string? Profit { get; set; }
	public string? Reserved { get; set; }
	public int ActiveOrderCount { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class UserOverviewEtf
{
	public string? UnrealizedProfit { get; set; }
	public string? Invested { get; set; }
	public string? FundsInTransit { get; set; }
	public string? HoldingsCurrentValue { get; set; }
	public string? Value { get; set; }
	public string? Profit { get; set; }
	public string? Reserved { get; set; }
	public int ActiveOrderCount { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class UserOverviewSmartCash
{
	public string? Value { get; set; }
	public string? Profit { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class UserOverviewValuatedAsset
{
	public string? UnrealizedProfit { get; set; }
	public DateTime? ValuatedAt { get; set; }
	public string? Value { get; set; }
	public string? Profit { get; set; }
	public string? Reserved { get; set; }
	public int ActiveOrderCount { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
