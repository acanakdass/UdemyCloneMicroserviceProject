using Microsoft.AspNetCore.Mvc;
using UdemyClone.Services.Discount.Services;

namespace UdemyClone.Services.Discount.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountsController : ControllerBase
{
 private readonly IDiscountService _discountService;

 public DiscountsController(IDiscountService discountService)
 {
  _discountService = discountService;
 }

 [HttpGet]
 public async Task<IActionResult> GetAll()
 {
  var result = await _discountService.GetAll();
  return Ok(result);
 }
}