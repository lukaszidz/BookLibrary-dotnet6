namespace BookLibrary.App.Configuration;

public sealed record AppSettings
{
    public string[] Cors { get; init; }
}
