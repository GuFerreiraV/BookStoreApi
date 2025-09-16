namespace BookStoreApi.Models
{
    /*
        Essa classe armazena os valores da propriedade appsettings.json do arquivo BookStoreDatabase 
        Os nomes das propriedades são idênticos para facilitar o processo de mapeamento
    */
    public class BookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BooksCollectionName { get; set; } = null!;
    }
}
