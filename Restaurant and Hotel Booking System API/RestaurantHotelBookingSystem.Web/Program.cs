
using Restaurant_and_Hotel_Booking_System_API;
using RestaurantHotelBookingSystem.Infrastructure;
using RestaurantHotelBookingSystem.Web.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.DescribeAllParametersInCamelCase();
    swagger.SwaggerDoc("v1", new() { 
        Title = "Restaurant and Hotel Booking System.Web",
        Description = "API for Restaurant and Hotel Booking System",
        Version = "v1" });
});

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.AllowAnyOrigin()  // Allow requests from your React app's origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
ConnectionStringUtility.RestaurantSystemConnectionString = builder.Configuration["RestaurantSystemConnectionString"];

ConnectionStringUtility.RestaurantSystemConnectionString = "server=(localdb)\\MSSQLLocalDB;database=RestaurantSystem;Integrated Security=false;MultipleActiveResultSets=True;";

var entest = builder.Configuration["Environment"];


builder.Services
     .AddScoped<ActiveUserHandler>()
     .AddApplicationCoreDependencies()
     .AddInfrastructureDependencies();

var app = builder.Build();

app.UseCors("AllowLocalhost");

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
