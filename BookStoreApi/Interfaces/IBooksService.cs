using BookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Interfaces
{
    public interface IBooksService
    {
        public Task<List<Book>> GetAsync();
        public Task<Book?> GetAsync(string id);
        public Task CreateAsync(Book newBook);
        public Task UpdateAsync(string id, Book updatedBook);
        public Task DeleteAsync(string id);
    }
}
