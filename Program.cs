using AnyTimePediatricsAPI.Middleware;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OBL_Zoho.Models;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services;
using OBL_Zoho.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//connection string
builder.Services.AddDbContext<OblZohoContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB")));

// Add services to the container.
builder.Services.AddScoped<IAppSettingsService, AppSettingsService>();
builder.Services.AddScoped<IZohoService, ZohoService>();

builder.Services.AddControllers();

builder.Services.Configure<FirebaseSetting>(builder.Configuration.GetSection("FIREBASE_CONFIG"));

builder.Services.AddSingleton<FirebaseApp>(provider =>
{
    var fbConfig = provider.GetRequiredService<IOptions<FirebaseSetting>>().Value;
    return FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromJson(JsonConvert.SerializeObject(fbConfig))
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OBL Zoho API's", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "OBL_Zoho.xml");
    c.IncludeXmlComments(filePath);
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true));
app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
