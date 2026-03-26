using Microsoft.Extensions.Logging;

namespace Mintos.API;

public class MintosClient
{
	private readonly MintosProxyApi _proxyApi;
	private readonly ILogger<MintosClient> _logger;

	public MintosClient(
		MintosProxyApi proxyApi,
		ILogger<MintosClient> logger)
	{
		_proxyApi = proxyApi;
		_logger = logger;
	}

	public void Initialize(string mwSessionId, string phpSessionId, string antiCsrfToken)
	{
		_proxyApi.SetCredentials(mwSessionId, phpSessionId, antiCsrfToken);
	}

	public Func<Task>? OnUnauthorizedAsync
	{
		get => _proxyApi.OnUnauthorizedAsync;
		set => _proxyApi.OnUnauthorizedAsync = value;
	}

	public MintosCredentials GetCurrentCredentials() => _proxyApi.GetCurrentCredentials();

	#region Authentication
	public async Task<RefreshResponse?> RefreshSessionAsync(string? referer = null)
	{
		var response = await _proxyApi.SendRequestAsync<RefreshResponse>(
			HttpMethod.Get,
			"webapp/api/auth/refresh?webappApi=true&marketplaceApi=false",
			referer: referer,
			xRequestedWith: "XMLHttpRequest");

		return response;
	}
	#endregion

	#region User
	public async Task<UserResponse?> GetUserAsync(string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<UserResponse>(
			HttpMethod.Get,
			"webapp/api/en/webapp-api/user",
			referer: referer);
	}

	public async Task<decimal> GetAvailableBalanceAsync(int currencyCode, string? referer = null)
	{
		var user = await GetUserAsync(referer);
		var aggregate = user?.Aggregates?.FirstOrDefault(a => a.Currency == currencyCode);

		if (aggregate == null)
			throw new Exception($"Aggregate not found for currency code: {currencyCode}");

		return decimal.TryParse(aggregate.AccountBalance, System.Globalization.NumberStyles.Any,
			System.Globalization.CultureInfo.InvariantCulture, out var balance) ? balance : 0;
	}
	#endregion

	#region Marketplace note series
	public async Task<SecondaryMarketResponse?> GetSecondaryMarketNotesAsync(SecondaryMarketRequest request, string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<SecondaryMarketResponse>(
			HttpMethod.Post,
			"webapp/api/marketplace-api/v1/note-series/secondary",
			body: request,
			referer: referer);
	}

	public async Task<PrimaryMarketNoteSeriesResponse?> GetPrimaryMarketNoteSeriesAsync(
		PrimaryMarketNoteSeriesRequest request,
		string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<PrimaryMarketNoteSeriesResponse>(
			HttpMethod.Post,
			"webapp/api/marketplace-api/v1/note-series/primary",
			body: request,
			referer: referer);
	}
	#endregion

	#region Cart Operations - Secondary Market
	public async Task AddSharesToCardAsync(ReserveShareRequestItem[] items, string? referer = null)
	{
		await _proxyApi.SendRequestAsync<object>(
			HttpMethod.Post,
			"webapp/api/marketplace-api/v2/cart/note-series-shares",
			body: items,
			referer: referer);
	}
	
	public async Task<CartSharesResponse?> GetSharesInCartAsync(string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<CartSharesResponse>(
			HttpMethod.Get,
			"webapp/api/marketplace-api/v1/cart/note-series-shares",
			referer: referer);
	}

	public async Task ClearSharesCartAsync(string? referer = null)
	{
		await _proxyApi.SendRequestAsync<object>(
			HttpMethod.Delete,
			"webapp/api/marketplace-api/v1/cart/note-series-shares",
			referer: referer);
	}
	
	public async Task<ConfirmSharesPurchaseResponse?> ConfirmSharesPurchaseAsync(string reference, string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<ConfirmSharesPurchaseResponse>(
			HttpMethod.Post,
			"webapp/api/marketplace-api/v1/cart/note-series-shares/confirm",
			body: new ConfirmSharesPurchaseRequest { Reference = reference },
			referer: referer);
	}
	#endregion

	#region Cart Operations - Primary Market
	public async Task<CartNotesResponse?> GetNotesInCartAsync(string? referer = null)
	{
		return await _proxyApi.SendRequestAsync<CartNotesResponse>(
			HttpMethod.Get,
			"webapp/api/marketplace-api/v1/cart/note-series",
			referer: referer);
	}

	public async Task ClearNotesCartAsync(string? referer = null)
	{
		await _proxyApi.SendRequestAsync<object>(
			HttpMethod.Delete,
			"webapp/api/marketplace-api/v1/cart/note-series",
			referer: referer);
	}
	#endregion
}
