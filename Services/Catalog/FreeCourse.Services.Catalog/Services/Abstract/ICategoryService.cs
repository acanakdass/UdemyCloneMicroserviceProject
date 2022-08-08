using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using UdemyClone.Shared.Results.Abstract;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace FreeCourse.Services.Catalog.Services.Abstract;

public interface ICategoryService
{
    Task<IDataResult<List<Category>>> GetAllAsync();
    Task<IDataResult<Category>> GetByIdAsync(string id);
    Task<IResult> AddAsync(CategoryDto categoryDto);
}