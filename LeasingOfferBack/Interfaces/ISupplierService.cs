using LeasingOfferBack.DTOs;

namespace LeasingOfferBack.Interfaces
{
    public interface ISupplierService
    {
        Task<List<SupplierTopDto>> GetTopSuppliersAsync(int count = 3);
    }
}