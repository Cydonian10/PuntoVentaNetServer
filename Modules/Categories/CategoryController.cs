using ApiStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiStore.Modules.Categories
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepoitory;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepoitory = categoryRepository;
        }

        [HttpPost("save")]
        public async Task<ActionResult> SaveOne([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                             .SelectMany(v => v.Errors)
                             .Select(e => e.ErrorMessage)
                             .ToList();

                return BadRequest(new { Errors = errors });
            }

            await _categoryRepoitory.SaveOne(dto);


            return Ok(new
            {
                message = "Create Category",
            });
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryRepoitory.List();

            return Ok(new
            {
                message = "List categories",
                data = categories
            });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveOne(Guid id)
        {
            var result = await _categoryRepoitory.RemoveOne(id);

            if (result)
                return Ok(new { message = "Eliminado exitosamente " });
            else
                return NotFound("Id no exist");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOne([FromBody] UpdateCategoryDto dto, Guid id)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                             .SelectMany(v => v.Errors)
                             .Select(e => e.ErrorMessage)
                             .ToList();

                return BadRequest(new { Errors = errors });
            }

            var result = await _categoryRepoitory.UpdateOne(dto, id);

            if (result)
                return Ok(new { message = "Actulizado exitosamente " });
            else
                return NotFound("Id no exist");
        }


    }
}
