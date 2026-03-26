using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mintos.API;

/// <summary>
/// GET accounts/{currency}/portfolio-distributions — portfolio breakdown by interest, term, status, country, etc.
/// </summary>
public class PortfolioDistributionsResponse
{
	public PortfolioMetricGroup? AverageInterestRate { get; set; }
	public PortfolioMetricGroup? AverageRemainingTime { get; set; }
	public PortfolioMetricGroup? InvestmentStatus { get; set; }
	public PortfolioMetricGroup? Countries { get; set; }
	public PortfolioMetricGroup? LoanOriginators { get; set; }
	public PortfolioMetricGroup? PledgeType { get; set; }

	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

public class PortfolioMetricGroup
{
	public decimal Average { get; set; }
	public List<PortfolioDistributionBucket>? Distribution { get; set; }
}

public class PortfolioDistributionBucket
{
	public string? Id { get; set; }
	public int SortId { get; set; }
	public string? Name { get; set; }
	public MoneyAmount? Total { get; set; }
	public int Count { get; set; }
}
