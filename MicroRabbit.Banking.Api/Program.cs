using MediatR;
using MicroRabbit.Banking.Api;
using MicroRabbit.Banking.Data;
using MicroRabbit.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.LicenseKey =
        "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg4NDgwMDAwIiwiaWF0IjoiMTc1Njk5NTMyNyIsImFjY291bnRfaWQiOiIwMTk5MTUxNDg1YWE3MTc4OGM3NzcxZDUzNjZmZWQ3OSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazRhaGE1eGQ4M2M3bjFqOWo5N2RqZXFzIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.iMio7RbPsXokowrYl0yvACMmpPTMSb22fFpIxvQ0XTHg-8oLTTVww113RtGPUUu4lKk6EcP__7wbXmyckbSGw_R26Slx4jvg6azLzISrUTpnCjSAxzxOxn-meSsZz_0LpMTLshQP-OHkh8NknIQ5_83zyQetb4TKMd_5eouaB5pB92xD4if8-eICxKvkl9arqDdi2gchvVjst2BVVDv2JT_o5a2qzYFo_izW_sdBUOmfLkz3PswTe-whNPqZPmcsh5W5WtyADT1phYyM00G6gBtwYQDl2Z8XtbaT0oJ_CVRjVSOoaY44JWBYHK_kFFbLy36YpsILTQ5hY21a8igH6A";
});


builder.Services
    .AddWebApi()
    .AddPersistence(builder.Configuration)
    .RegisterServices();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

// Serve static files for the JSON definitions
app.UseStaticFiles();

// Configure Swagger UI with custom options
app.UseSwaggerUI(c =>
{
    // Add multiple services with dropdowns for JSON files
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
   

    // Customize the UI (optional)
    c.EnableDeepLinking();
    c.DisplayOperationId();
});

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//});
app.MapControllers();
app.Run();

