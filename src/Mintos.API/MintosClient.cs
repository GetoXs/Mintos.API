using Microsoft.Extensions.Logging;

namespace Mintos.API;

public class MintosClient : IDisposable
{
    private readonly MintosProxyApi _proxyApi;
    private readonly ILogger<MintosClient>? _logger;

    public MintosClient(ILogger<MintosClient>? logger = null, Dictionary<string, string>? extraHeaders = null)
    {
        _proxyApi = new MintosProxyApi(extraHeaders);
        _logger = logger;
    }

    public void Initialize(string mwSessionId, string phpSessionId, string antiCsrfToken)
    {
        _proxyApi.SetCredentials(mwSessionId, phpSessionId, antiCsrfToken);
    }

    public string? RefreshReferer { get; set; }

    public async Task<RefreshResponse?> RefreshSessionAsync()
    {
        var response = await _proxyApi.SendRequestAsync<RefreshResponse>(
            HttpMethod.Get,
            "webapp/api/auth/refresh?webappApi=true&marketplaceApi=false",
            referer: RefreshReferer,
            xRequestedWith: "XMLHttpRequest");

        return response;
    }

    public string? GetUserReferer { get; set; }

    public async Task<UserResponse?> GetUserAsync()
    {
        return await _proxyApi.SendRequestAsync<UserResponse>(
            HttpMethod.Get,
            "webapp/api/en/webapp-api/user",
            referer: GetUserReferer);
    }

    public async Task<decimal> GetAvailableBalanceAsync(int currencyCode = 978) // 978 = EUR
    {
        var user = await GetUserAsync();
        var aggregate = user?.Aggregates?.FirstOrDefault(a => a.Currency == currencyCode);

        if (aggregate == null)
            return 0;

        return decimal.TryParse(aggregate.AccountBalance, System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out var balance) ? balance : 0;
    }

    public string? SecondaryMarketReferer { get; set; }

    public async Task<SecondaryMarketResponse?> GetSecondaryMarketNotesAsync(SecondaryMarketRequest request)
    {
        return await _proxyApi.SendRequestAsync<SecondaryMarketResponse>(
            HttpMethod.Post,
            "webapp/api/marketplace-api/v1/note-series/secondary",
            body: request,
            referer: SecondaryMarketReferer);
    }

    // TODO: Implement investment endpoint
    public Task<object?> InvestInNoteAsync(string shareId, decimal amount)
    {
        _logger?.LogWarning("InvestInNoteAsync not implemented yet. ShareId: {ShareId}, Amount: {Amount}", shareId, amount);
        throw new NotImplementedException("Investment endpoint not implemented yet.");
    }

    public void Dispose()
    {
        _proxyApi.Dispose();
        GC.SuppressFinalize(this);
    }
}
