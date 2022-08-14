using UdemyClone.Services.Discount.Models;
using UdemyClone.Shared.Results.Abstract;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace UdemyClone.Services.Discount.Services;

public interface IDiscountService
{
    Task<IDataResult<List<DiscountModel>>> GetAll();
    Task<IDataResult<DiscountModel>> GetById(int id);
    Task<IResult> Add(DiscountModel discountModel);
    Task<IResult> Update(DiscountModel discountModel);
    Task<IResult> Delete(int id);
    Task<IDataResult<DiscountModel>> VerifyAndReturnByCodeAndUserId(string code, string user);
}