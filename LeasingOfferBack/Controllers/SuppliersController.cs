using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using LeasingOfferBack.Data;

namespace LeasingOfferBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public SuppliersController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet("top")]
        //public async Task<IActionResult> GetTopSuppliers()
        //{
        //    var topSuppliers = await _context.Suppliers
        //        .Select(s => new
        //        {
        //            s.Id,
        //            s.Name,
        //            OfferCount = _context.Offers.Count(o => o.SupplierId == s.Id)
        //        })
        //        .OrderByDescending(s => s.OfferCount)
        //        .Take(3)
        //        .ToListAsync();

        //    return Ok(topSuppliers);
        //}
    }
}
