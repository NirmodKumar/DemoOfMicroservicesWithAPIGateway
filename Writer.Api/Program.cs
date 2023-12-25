using Writer.Api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWriterRepository, WriterRepository>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapGet("/GetAllWriter", (IWriterRepository _writerRepository) =>
{
    var result = _writerRepository.GetAll();

    return Results.Ok(result);
})
.WithName("GetAllWriter");

app.MapGet("/GetWriterById", (int id, IWriterRepository _writerRepository) =>
{
    var result = _writerRepository.Get(id);
    if (result is null)
        return Results.NotFound();
    return Results.Ok(result);
})
.WithName("GetWriterById");


app.MapPost("/InsertWriter", (Writer.Api.Models.Writer writer, IWriterRepository _writerRepository) =>
{
    if (writer is null)
    {
        throw new ArgumentNullException(nameof(writer));
    }

    var result = _writerRepository.Insert(writer);

    return Results.Created($"/get/{result.Id}", result);
})
.WithName("InsertWriter");

app.Run();