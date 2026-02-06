using BG.Inventario.API;
using BG.Inventario.API.Configuration;
using BG.Inventario.Application;
using BG.Inventario.Persistence;
using BG.Inventario.External;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilogLogging();

builder.Services
    .AddWebApi()
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddExternal(builder.Configuration);

var app = builder.Build();
//app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
