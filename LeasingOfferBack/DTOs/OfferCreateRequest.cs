namespace LeasingOfferBack.DTOs
{
    public class OfferCreateRequest
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int SupplierId { get; set; }
    }
}
