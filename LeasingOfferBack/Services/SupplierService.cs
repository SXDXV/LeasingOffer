using LeasingOfferBack.Data;
using LeasingOfferBack.DTOs;
using LeasingOfferBack.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeasingOfferBack.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierTopDto>> GetTopSuppliersAsync(int count = 3)
        {
            var topSuppliers = await _context.Suppliers
                .Select(s => new SupplierTopDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    OfferCount = _context.Offers.Count(o => o.SupplierId == s.Id)
                })
                .OrderByDescending(s => s.OfferCount)
                .Take(count)
                .ToListAsync();

            return topSuppliers;
        }
    }
}
