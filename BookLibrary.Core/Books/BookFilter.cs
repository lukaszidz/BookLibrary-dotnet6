﻿namespace BookLibrary.App.Models;
using BookLibrary.Core.Books;

public sealed record BookFilter(string Title, string Publisher, int? AuthorId, BookType? Type, string Isbn, int? CategoryId);