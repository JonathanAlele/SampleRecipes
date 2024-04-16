using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
namespace Recipes.Controllers
{
	/*
	 * This is the class that defines the endpoints and routing for the API
	 */
	[Route("api/[controller]")] //api/recipes
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly RecipesService _recipesService;
		
		public RecipesController(RecipesService recipesService)
		{
			_recipesService = recipesService;
		}
		[HttpGet]
		public async Task<List<Recipe>> Get()
		{
			return await _recipesService.GetAsync();
		}

		[HttpGet("{name}")]
		public async Task<Recipe> Get(string name)
		{
			ArgumentNullException.ThrowIfNullOrWhiteSpace($"{nameof(name)} cannot be null");
			return await _recipesService.GetAsync(name);
		}

		[HttpPost]
		public Task CreateNewDish(Recipe dish)
		{
			ArgumentNullException.ThrowIfNullOrEmpty($"{nameof(dish)} cannot be null");
			return _recipesService.CreateAsync(dish);
		}

		[HttpPut]
		public Task UpdateDish([FromBody] Recipe dish)
		{
			ArgumentNullException.ThrowIfNullOrEmpty($"{nameof(dish)} cannot be null");
			return _recipesService.UpdateAsync(dish);
		}

		[HttpDelete("{dish}")]
		public Task DeleteDish(Recipe dish)
		{
			ArgumentNullException.ThrowIfNullOrEmpty($"{nameof(dish)} cannot be null");
			return _recipesService.RemoveAsync(dish);
		}
	}
}
