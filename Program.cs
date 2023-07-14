using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using newcontableapi.Repository;
using newcontableapi.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers(options =>
            {
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            }).AddNewtonsoftJson()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
    {
        options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
                {
                    builder
                        .WithOrigins("*")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH");
                });
    });
builder.Services.AddScoped<IMonedasRepository, MonedasRepository>();
builder.Services.AddScoped<IMonedasService, MonedasService>();
builder.Services.AddScoped<IPeriodoContableRepostory, PeriodoContableRepostory>();
builder.Services.AddScoped<IPeriodosContablesService, PeriodosContablesService>();
builder.Services.AddScoped<ICentroCostosRepository, CentroCostosRepository>();
builder.Services.AddScoped<ICentroCostosService, CentroCostosService>();
builder.Services.AddScoped<IPlanCuentasRepository, PlanCuentasRepository>();
builder.Services.AddScoped<IPlanCuentasService, PlanCuentasService>();
builder.Services.AddScoped<IAsientosContablesRepository, AsientosContablesRepository>();
builder.Services.AddScoped<IAsientosContablesService, AsientosContablesService>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

app.UseResponseCaching();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();