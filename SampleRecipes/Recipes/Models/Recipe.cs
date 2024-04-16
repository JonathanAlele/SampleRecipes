using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipes.Models
{
	/*
	 * This class models the shape of the Recipe to perform CRUD on the DB
	 */
	public record Recipe
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; }

		[BsonElement("name")]
		public string? Name { get; set; }
		[BsonElement("description")]
		public string? Description { get; set; }
		[BsonElement("createdTs")]
		public DateTime CreatedTs { get; init; }
		[BsonElement("updateTs")]
		public DateTime UpdateTs { get; set; }

		public Recipe()
		{
			CreatedTs = DateTime.Now;
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
