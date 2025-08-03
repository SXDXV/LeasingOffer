namespace LeasingOfferBack.DTOs
{
    public class OfferSearchRequest
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
    }
}
