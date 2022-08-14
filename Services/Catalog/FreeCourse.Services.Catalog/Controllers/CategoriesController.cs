using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyClone.Shared.Controllers;

namespace FreeCourse.Services.Catalog.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _categoryService.GetAllAsync();
            return CreateActionResult(res, StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var res = await _categoryService.AddAsync(category);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return CreateActionResult(result, StatusCodes.Status200OK);
        }
    }
}
