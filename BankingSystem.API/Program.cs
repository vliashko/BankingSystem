using BankingSystem.API.Extensions;
using BankingSystem.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();
builder.AddLogger();

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
app.UseAuthentication();
app.UseAuthorization();


app.Run();
