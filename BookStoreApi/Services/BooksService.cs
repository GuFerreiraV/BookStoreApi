using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services
{
    public class BooksService : IBooksService
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            // lê a instância do servidor para executar operações de banco de dados. O construtor desta classe é fornecido na cadeia de conexão.
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDataBase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);
        
            _booksCollection = mongoDataBase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task CreateAsync(Book newBook) => await _booksCollection.InsertOneAsync(newBook);

        public async Task DeleteAsync(string id) => await _booksCollection.DeleteOneAsync(x => x.Id == id);
        
        public async Task<List<Book>> GetAsync() => await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) => await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Book updatedBook) => await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
    }
}
