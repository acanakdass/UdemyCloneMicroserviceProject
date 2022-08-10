using System.Text.Json;
using UdemyClone.Services.Cart.DTOs;
using UdemyClone.Shared.Constants;
using UdemyClone.Shared.Results.Abstract;
using UdemyClone.Shared.Results.Concrete;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace UdemyClone.Services.Cart.Services;

public class CartService : ICartService
{
    private readonly RedisService _redisService;

    public CartService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<IDataResult<CartDto>> GetCart(string userId)
    {
        var cart = await _redisService.GetDb().StringGetAsync(userId);
        if (String.IsNullOrEmpty(cart.ToString()))
        {
            return new SuccessDataResult<CartDto>(null, ResponseMessages.NotFound("Cart"));
        }

        return new SuccessDataResult<CartDto>(JsonSerializer.Deserialize<CartDto>(cart),
            ResponseMessages.NotFound("Cart"));
    }

    public async Task<IResult> SaveOrUpdate(CartDto cartDto)
    {
        var status = await _redisService.GetDb().StringSetAsync(cartDto.UserId, JsonSerializer.Serialize(cartDto));
        if (status)
            return new SuccessResult("Action suceed!");
        return new ErrorResult("Error while save or update cart!");
    }

    public async Task<IResult> Delete(string userId)
    {
        var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        return status
            ? new SuccessResult(ResponseMessages.Deleted("Cart"))
            : new ErrorResult(ResponseMessages.NotFound("Cart"));
    }
}