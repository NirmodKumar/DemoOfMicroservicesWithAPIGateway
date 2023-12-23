using Article.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/GetAll", (IArticleRepository _articleRepository) =>
{
    return Results.Ok(_articleRepository.GetAll());
})
.WithName("GetAll");

app.MapGet("/GetById", (int id, IArticleRepository _articleRepository) =>
{
    var article = _articleRepository.Get(id);
    if (article is null)
        return Results.NotFound();
    return Results.Ok(article);
})
.WithName("GetById");

app.MapDelete("/Delete", (int id, IArticleRepository _articleRepository) =>
{
    var deletedId = _articleRepository.Delete(id);
    if (deletedId == 0)
        return Results.NotFound();
    return Results.NoContent();
})
.WithName("Delete");

app.Run();