namespace Mintos.API;

public class UserResponse
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public string? Email { get; set; }
	public List<AccountAggregate>? Aggregates { get; set; }
}

public class AccountAggregate
{
	public int Currency { get; set; }
	public string? AccountBalance { get; set; }
	public string? Reserved { get; set; }
	public string? Total { get; set; }
	public string? TotalReceivedInterest { get; set; }
	public string? TotalReceivedLatePaymentFee { get; set; }
	public string? TotalSecondaryMarketProfit { get; set; }
	public string? TotalCurrencyExchangeFeePaid { get; set; }
	public string? TotalSecondaryMarketFeePaid { get; set; }
	public string? TotalMintosServiceFeePaid { get; set; }
	public string? TotalReceivedReferAfriendBonus { get; set; }
	public string? TotalReceivedReferredByAFriendBonus { get; set; }
	public string? TotalReceivedAffiliateBonus { get; set; }
	public string? TotalReceivedCashbackBonus { get; set; }
	public string? TotalReceivedActivationBonus { get; set; }
	public string? TotalReceivedWelcomeBonus { get; set; }
	public string? TotalReceivedBonus { get; set; }
	public string? KeepUninvestedLimit { get; set; }
	public string? TotalServiceFees { get; set; }
	public string? TotalBonus { get; set; }
	public string? TotalWithholdingTaxes { get; set; }
}
