using DemoWebAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Console.WriteLine(builder.Configuration.GetConnectionString("Default"));

// Permet d'ajouter le service (middleware) lié à openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/openapi/v1.json", "v1");
    //});
    app.MapScalarApiReference(options =>
    {
        options.Theme = ScalarTheme.Laserwave;
    });

}

app.UseHttpsRedirection();

// -- Routing
app.MapGet("/bonjour", () => "Bonjour les devenir développeur !");
app.MapGet("/personne", () => new Personne { Lastname = "Geerts" });

app.MapControllers();

app.Run();