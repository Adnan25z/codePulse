using codePulse.API.Data;
using codePulse.API.Models.Domain;
using codePulse.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace codePulse.API.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            //Domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);
        }
    }
}
