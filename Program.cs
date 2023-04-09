using BackgroundtasksForEcommerceTutorial.BackgroundTasks;
using BackgroundtasksForEcommerceTutorial.Serves;
using BackgroundtasksForEcommerceTutorial.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//serves
builder.Services.AddTransient<IDiscountCode, DiscountCode>();

/*  Background Task */

builder.Services.AddScoped<SendDiscountCodeTask>();

// Register as singleton first so it can be injected through Dependency Injection
builder.Services.AddSingleton<PeriodicHostedService>();

// Add as hosted service using the instance registered as singleton before
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<PeriodicHostedService>());
/* End Background Task */


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
