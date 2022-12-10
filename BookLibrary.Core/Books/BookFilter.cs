namespace BookLibrary.App.Models;
using BookLibrary.Core.Books;

public sealed record BookFilter(string Title, string Publisher, string Author, BookType? Type, string Isbn, string Category);
