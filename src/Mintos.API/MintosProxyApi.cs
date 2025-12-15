using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Mintos.API;

public class MintosProxyApi : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly CookieContainer _cookieContainer = new();
    private string? _antiCsrfToken;
    private readonly Dictionary<string, string>? _extraHeaders;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public MintosProxyApi(Dictionary<string, string>? extraHeaders = null)
    {
        var clientHandler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli,
            UseCookies = true,
            CookieContainer = _cookieContainer,
        };
        _httpClient = new HttpClient(clientHandler)
        {
            BaseAddress = new Uri("https://www.mintos.com/"),
        };
        _extraHeaders = extraHeaders;
    }

    public void SetCredentials(string mwSessionId, string phpSessionId, string antiCsrfToken)
    {
        var uri = new Uri("https://www.mintos.com");
        _cookieContainer.Add(uri, new Cookie("MW_SESSION_ID", mwSessionId));
        _cookieContainer.Add(uri, new Cookie("PHPSESSID", phpSessionId));
        _antiCsrfToken = antiCsrfToken;
    }

    public async Task<T?> SendRequestAsync<T>(HttpMethod method, string url, object? body = null, string? referer = null)
    {
        using var request = new HttpRequestMessage(method, url)
        {
            Content = body != null ? JsonContent.Create(body, options: JsonOptions) : null,
        };

        request.Headers.Add("Referer", referer ?? "https://www.mintos.com/en/");
        
        if (_extraHeaders != null)
        {
            foreach (var header in _extraHeaders)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        // CSRF token
        if (!string.IsNullOrEmpty(_antiCsrfToken))
        {
            request.Headers.Add("anti-csrf-token", _antiCsrfToken);
        }

        var response = await _httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedAccessException(await response.Content.ReadAsStringAsync());
        }

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"HTTP {(int)response.StatusCode}: {errorContent}");
        }

        var content = await response.Content.ReadAsStringAsync();
        
        if (typeof(T) == typeof(string))
            return (T)(object)content;

        if (string.IsNullOrWhiteSpace(content))
            return default;

        return JsonSerializer.Deserialize<T>(content, JsonOptions);
    }

    public bool IsAuthenticated =>
        _cookieContainer.GetCookies(new Uri("https://www.mintos.com"))
            .Cast<Cookie>()
            .Any(c => c.Name == "MW_SESSION_ID");

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
