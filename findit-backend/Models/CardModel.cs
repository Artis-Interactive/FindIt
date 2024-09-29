namespace findit_backend.Models
{
    public class CardModel
    {
        public string? CardId { get; }
        public string? CardNumber { get; set; }
        public string? NameOnCard { get; set; }
        public string? ExpirationDate { get; set; }
    }
}
