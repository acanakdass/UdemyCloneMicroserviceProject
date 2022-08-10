using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyClone.Shared.Controllers;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CoursesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _categoryService.GetAllAsync();
            var ress = res;
            return CreateActionResult(res, StatusCodes.Status200OK);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return CreateActionResult(result, StatusCodes.Status200OK);
        }
    }
}
