using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrionTek.Business.Implementations;
using OrionTek.Business.Services;
using OrionTek.DataAccess;
using OrionTek.Repopsitory.Contracts;
using OrionTek.Repopsitory.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext
builder.Services.AddDbContext<OrionTekContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddControllers();


builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

//Repository and services injections
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<IEmployeeRepository, EmployeeService>();
builder.Services.AddTransient<IEmployeeBusiness, EmployeeBusinessService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OrionTek API",
        Version = "v1"
    });
});

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
