namespace BookLibrary.App.Models;

internal sealed record BookResult(string Title, string Type, string Isbn, string Category, IEnumerable<string> Authors, string Publisher, int AvailableCopies, int AllCopies);
