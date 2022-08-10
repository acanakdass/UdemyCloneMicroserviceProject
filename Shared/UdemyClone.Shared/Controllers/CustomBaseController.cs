using Microsoft.AspNetCore.Mvc;
using UdemyClone.Shared.Results.Abstract;

namespace UdemyClone.Shared.Controllers;

public class CustomBaseController:ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(IDataResult<T> result,int statusCode)
    {
        return new ObjectResult(result) {StatusCode = statusCode};
    }
    [NonAction]
    public IActionResult CreateActionResult(IResult result,int statusCode)
    {
        return new ObjectResult(result) {StatusCode = statusCode};
    }
}