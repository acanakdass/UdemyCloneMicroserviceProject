using UdemyClone.Shared.Results.Abstract;
using FreeCourse.Services.Catalog.Models;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace FreeCourse.Services.Catalog.Services.Abstract;

public interface IBaseService<T> where T:class,IModel
{
}