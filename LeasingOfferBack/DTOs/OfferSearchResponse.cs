namespace LeasingOfferBack.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int SupplierId { get; set; }  //для логики
        public string SupplierName { get; set; }  // для отображения
        public DateTime RegisteredAt { get; set; }
    }

    public class OfferSearchResponse
    {
        public List<OfferDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
