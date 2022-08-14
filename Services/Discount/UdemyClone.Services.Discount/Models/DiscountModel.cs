using Dapper.Contrib.Extensions;

namespace UdemyClone.Services.Discount.Models;

[Table("discounts")]
public class DiscountModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int Rate { get; set; }
    public string Code { get; set; }
    public DateTime CreatedDate { get; set; }
}