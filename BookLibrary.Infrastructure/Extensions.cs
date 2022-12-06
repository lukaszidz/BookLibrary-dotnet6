namespace BookLibrary.Infrastructure;

public static class Extensions
{
    public static bool IgnoreCaseEquals(this string input, string compareTo) =>
        input.Equals(compareTo, StringComparison.InvariantCultureIgnoreCase);
}
