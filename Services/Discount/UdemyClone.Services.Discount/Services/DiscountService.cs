using System.Data;
using Dapper;
using Npgsql;
using UdemyClone.Services.Discount.Models;
using UdemyClone.Shared.Constants;
using UdemyClone.Shared.Results.Abstract;
using UdemyClone.Shared.Results.Concrete;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace UdemyClone.Services.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;

    public DiscountService(IConfiguration configuration)
    {
        _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL"));
        _configuration = configuration;
    }

    public async Task<IDataResult<List<DiscountModel>>> GetAll()
    {
        var discounts = await _dbConnection.QueryAsync<DiscountModel>("SELECT * FROM discounts");
        return new SuccessDataResult<List<DiscountModel>>(discounts.ToList(), ResponseMessages.Listed("Discounts"));
    }

    public async Task<IDataResult<DiscountModel>> GetById(int id)
    {
        var discounts =
            await _dbConnection.QueryAsync<DiscountModel>("SELECT * FROM discounts WHERE id=@id", new {id = id});
        var result = discounts.SingleOrDefault();
        if (result == null)
            return new ErrorDataResult<DiscountModel>(result, ResponseMessages.NotFound("Discount"));
        return new SuccessDataResult<DiscountModel>(result, ResponseMessages.Listed("Discount"));
    }

    public async Task<IResult> Add(DiscountModel discountModel)
    {
        var status = await _dbConnection.ExecuteAsync(
            "INSERT INTO discounts(userid,rate,code) VALUES(@UserId,@Rate,@Code)", discountModel);
        if (status > 0)
            return new SuccessResult(ResponseMessages.Added("Discount"));
        return new ErrorResult(ResponseMessages.FailedAdd("Discount"));
    }

    public async Task<IResult> Update(DiscountModel discountModel)
    {
        var status = await _dbConnection.ExecuteAsync(
            "UPDATE discounts SET userid=@UserId,rate=@Rate,code =@Code WHERE id=@Id)", discountModel);
        if (status > 0)
            return new SuccessResult(ResponseMessages.Updated("Discount"));
        return new ErrorResult(ResponseMessages.FailedUpdate("Discount"));
    }

    public async Task<IResult> Delete(int id)
    {
        var status = await _dbConnection.ExecuteAsync(
            $"DELETE FROM discounts WHERE id={id})");
        if (status > 0)
            return new ErrorResult(ResponseMessages.FailedDelete("Discount"));
        return new SuccessResult(ResponseMessages.Deleted("Discount"));
    }

    public async Task<IDataResult<DiscountModel>> VerifyAndReturnByCodeAndUserId(string code, string user)
    {
        var discount =
            await _dbConnection.QueryAsync<DiscountModel>(
                $"SELECT * FROM discounts WHERE userid={user} AND code={code}");
        var result = discount.FirstOrDefault();
        if (result == null)
            return new ErrorDataResult<DiscountModel>(result, ResponseMessages.NotFound("Discount"));
        return new SuccessDataResult<DiscountModel>(result, ResponseMessages.Listed("Discount"));
    }
}