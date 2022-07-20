using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var b = new ODataConventionModelBuilder();
b.EntitySet<TestEntity>(nameof(TestEntity));
var model = b.GetEdmModel();

builder.Services
    .AddControllers()
    .AddOData(opt => opt
        .EnableQueryFeatures()
        .AddRouteComponents(model)
        .TimeZone = TimeZoneInfo.Utc
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseODataRouteDebug();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
