namespace BookLibrary.Infrastructure.Configuration;

public sealed record InfrastructureSettings
{
    public DatabaseSettings Database { get; init; }
}

public sealed record DatabaseSettings
{
    public string ConnectionString { get; init; }
}
