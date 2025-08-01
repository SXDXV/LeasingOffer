using LeasingOfferBack.DTOs;
using LeasingOfferBack.Interfaces;
using LeasingOfferBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeasingOfferBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OffersController : ControllerBase
{
    private readonly IOfferService _service;

    public OffersController(IOfferService service)
    {
        _service = service;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] OfferSearchRequest request)
    {
        var result = await _service.SearchOffersAsync(request);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] OfferCreateRequest request)
    {
        var createdOffer = await _service.CreateOfferAsync(request);
        return CreatedAtAction(nameof(Create), new { id = createdOffer.Id }, createdOffer);
    }
}
