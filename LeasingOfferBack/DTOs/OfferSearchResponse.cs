namespace LeasingOfferBack.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int SupplierId { get; set; }
        public DateTime RegisteredAt { get; set; }
    }

    public class OfferSearchResponse
    {
        public List<OfferDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
