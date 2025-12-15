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
}

