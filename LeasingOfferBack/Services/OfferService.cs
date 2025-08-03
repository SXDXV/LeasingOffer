using LeasingOfferBack.Data;
using LeasingOfferBack.DTOs;
using LeasingOfferBack.Interfaces;
using Microsoft.EntityFrameworkCore;
using LeasingOfferBack.Entities;

namespace LeasingOfferBack.Services;

public class OfferService : IOfferService
{
    private readonly AppDbContext _context;

    public OfferService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OfferSearchResponse> SearchOffersAsync(OfferSearchRequest request)
    {
        var query = _context.Offers
            .Include(o => o.Supplier)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Brand))
            query = query.Where(o => o.Brand.Contains(request.Brand));

        if (!string.IsNullOrWhiteSpace(request.Model))
            query = query.Where(o => o.Model.Contains(request.Model));

        if (!string.IsNullOrWhiteSpace(request.SupplierName))
            query = query.Where(o => o.Supplier.Name.Contains(request.SupplierName));

        //if (request.SupplierId.HasValue)
        //    query = query.Where(o => o.SupplierId == request.SupplierId.Value);

        var totalCount = await query.CountAsync();

        var items = await query
            .Select(o => new OfferDto
            {
                Id = o.Id,
                Brand = o.Brand,
                Model = o.Model,
                SupplierId = o.SupplierId,
                SupplierName = o.Supplier.Name,
                RegisteredAt = o.RegisteredAt
            })
            .ToListAsync();

        return new OfferSearchResponse
        {
            TotalCount = totalCount,
            Items = items
        };
    }

    public async Task<OfferDto> CreateOfferAsync(OfferCreateRequest request)
    {
        var offer = new Offer
        {
            Brand = request.Brand,
            Model = request.Model,
            SupplierId = request.SupplierId,
            RegisteredAt = DateTime.UtcNow
        };

        _context.Offers.Add(offer);
        await _context.SaveChangesAsync();

        return new OfferDto
        {
            Id = offer.Id,
            Brand = offer.Brand,
            Model = offer.Model,
            SupplierId = offer.SupplierId,
            RegisteredAt = offer.RegisteredAt
        };
    }
}
