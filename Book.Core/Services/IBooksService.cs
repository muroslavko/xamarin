using System;

namespace Books.Core.Services
{
    public interface IBooksService
    {
        void StartSearchAsync(string whatFor, Action<BookSearchResult> success, Action<Exception> error);
        void SelectAsync(string address, Action<BookSearchItem> success, Action<Exception> error);
    }
}