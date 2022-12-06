﻿namespace BookLibrary.App.Models;

using BookLibrary.Core.Books;

internal sealed record BookResult(string Title, BookType Type, string Isbn, string Category, IEnumerable<string> Authors, string Publisher, int AvailableCopies, int AllCopies);