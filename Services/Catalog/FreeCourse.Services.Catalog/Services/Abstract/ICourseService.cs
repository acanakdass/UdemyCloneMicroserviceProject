using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using UdemyClone.Shared.Results.Abstract;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace FreeCourse.Services.Catalog.Services.Abstract;

public interface ICourseService:IBaseService<Course>
{
    Task<IDataResult<List<Course>>> GetAllAsync();
    Task<IDataResult<List<Course>>> GetAllWithCategoriesAsync();
    Task<IDataResult<Course>> GetByIdAsync(string id);
    Task<IResult> AddAsync(CourseCreateDto model);
}