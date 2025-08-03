using LeasingOfferBack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeasingOfferBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SuppliersController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopSuppliers()
        {
            var result = await _service.GetTopSuppliersAsync();
            return Ok(result);
        }
    }
}
