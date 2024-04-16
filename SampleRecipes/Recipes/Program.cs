using Recipes.Models;
using Recipes.Services;

var builder = WebApplication.CreateBuilder(args);

////////////////////////////////////	SERVICES	//////////////////////////////////////////
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RecipesDatabaseSettings>(builder.Configuration.GetSection("RecipesDB"));
builder.Services.AddSingleton<RecipesService>();
//////////////////////////////////////////////////////////////////////////////////////////////




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
