namespace Mintos.API;

public class MintosCredentials
{
    public string? MintosMwSessionId { get; set; }
    public string? MintosPhpSessionId { get; set; }
    public string? MintosAntiCsrfToken { get; set; }

    public bool IsNull() => 
        string.IsNullOrEmpty(MintosMwSessionId) || 
        string.IsNullOrEmpty(MintosPhpSessionId) || 
        string.IsNullOrEmpty(MintosAntiCsrfToken);

    public bool IsValid() => !IsNull();
}

