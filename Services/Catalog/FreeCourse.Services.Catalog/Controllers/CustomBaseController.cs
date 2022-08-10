using Microsoft.AspNetCore.Mvc;
using UdemyClone.Shared.Results.Abstract;

namespace FreeCourse.Services.Catalog.Controllers;

public class CustomBaseController:ControllerBase
{
    public IActionResult CreateActionResult<T>(IDataResult<T> result,int statusCode)
    {
        return new ObjectResult(result) {StatusCode = statusCode};
    }
}