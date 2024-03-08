using BankingSystem.API.Extensions;
using BankingSystem.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseAuthorization();


app.Run();
