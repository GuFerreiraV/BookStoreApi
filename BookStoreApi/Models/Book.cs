// MongoDB libs 
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BookStoreApi.Models
{
    public class Book
    {
        [BsonId] // Designa a propriedade como a chave primária do documento
        [BsonRepresentation(BsonType.ObjectId)] // Permite a passagem do parâmetro como tipo string em vez de ObjectId, Mongo processa a conversão de string para ObjectId
        public string? Id { get; set; } // propriedade necessária para mapear o objeto para coleção do MongoDB

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;

        public string Price { get; set; }

        [BsonElement("Category")]
        public string GenderBook { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
