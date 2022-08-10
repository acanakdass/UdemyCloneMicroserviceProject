using UdemyClone.Services.Cart.DTOs;
using UdemyClone.Shared.Results.Abstract;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace UdemyClone.Services.Cart.Services;

public interface ICartService
{
    Task<IDataResult<CartDto>> GetCart(string userId);
    Task<IResult> SaveOrUpdate(CartDto cartDto);
    Task<IResult> Delete(string userId);
    
    
}