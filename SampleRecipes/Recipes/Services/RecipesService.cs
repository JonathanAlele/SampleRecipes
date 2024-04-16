using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recipes.Models;
namespace Recipes.Services
{
	/*
	 * This class defines the CRUD operations on the DB. The methods here are called by the RecipesController
	 */

	public class RecipesService
	{
		private readonly IMongoCollection<Recipe> _recipesCollection;

		public RecipesService(IOptions<RecipesDatabaseSettings> recipeDatabaseSettings)
		{
			var mongoClient = new MongoClient(recipeDatabaseSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(recipeDatabaseSettings.Value.DatabaseName);

			_recipesCollection = mongoDatabase.GetCollection<Recipe>(recipeDatabaseSettings.Value.RecipesCollectionName);
		}

		public async Task<List<Recipe>> GetAsync() => await _recipesCollection.Find(_ => true).ToListAsync();

		public async Task<Recipe?> GetAsync(string name) => await _recipesCollection.Find(x => x.Name == name).FirstAsync();

		public async Task CreateAsync(Recipe recipe) => await _recipesCollection.InsertOneAsync(recipe);

		public async Task UpdateAsync(Recipe recipe) => await _recipesCollection.ReplaceOneAsync(x => x.Name == recipe.Name, recipe);

		public async Task RemoveAsync(Recipe recipe) => await _recipesCollection.DeleteOneAsync(x => x.Name == recipe.Name);
	}
}
