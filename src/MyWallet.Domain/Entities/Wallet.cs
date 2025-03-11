namespace MyWallet.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public Wallet(int id, string documentId, string documentType, string name) : base(id)
        {
            DocumentId = documentId;
            DocumentType = documentType;
            Name = name;
        }
        public Wallet(string documentId, string documentType, string name)
        {
            DocumentId = documentId;
            DocumentType = documentType;
            Name = name;
        }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; private set; }
        public decimal Balance { get; set; } = 0.0m;
    }
}
