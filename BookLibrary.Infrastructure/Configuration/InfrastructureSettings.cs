namespace BookLibrary.Infrastructure.Configuration;

public sealed class InfrastructureSettings
{
    public DatabaseSettings Database { get; init; }
}

public sealed class DatabaseSettings
{
    public string ConnectionString { get; init; }
}
