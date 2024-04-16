namespace Recipes.Models
{
	public class RecipesDatabaseSettings
	{
		public string ConnectionString { get; set; } = "mongodb://localhost:27017";
		public string DatabaseName { get; set; } = "RecipesDB";
		public string RecipesCollectionName { get; set; } = "Recipes";
	}
}
