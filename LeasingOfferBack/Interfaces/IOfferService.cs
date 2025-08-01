using LeasingOfferBack.DTOs;

namespace LeasingOfferBack.Interfaces
{
    public interface IOfferService
    {
        Task<OfferSearchResponse> SearchOffersAsync(OfferSearchRequest request);
        Task<OfferDto> CreateOfferAsync(OfferCreateRequest request);
    }
}
