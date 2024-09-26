using AccountsManager.Api.Commons;
using AccountsManager.Api.Middlewares;
using AccountsManager.Application.Common;
using AccountsManager.Infrastructure.Common;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.ContractResolver = new BaseClassJsonContractResolver();

        // Json optimizations
        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        o.SerializerSettings.Formatting = Formatting.None;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddHandlingExceptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHandlingExceptions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();