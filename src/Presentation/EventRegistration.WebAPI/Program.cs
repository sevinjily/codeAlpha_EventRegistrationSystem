using EventRegistration.Persistence;
using EventRegistration.Application;
using EventRegistration.Infrastructure;
using EventRegistration.Mapper;
using EventRegistration.Application.Exceptions;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventRegistration API", Version = "v1", Description = "EventRegistration API swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description = "You can enter your JWT token below. \r\n\r\nType 'Bearer' followed by a space and then your token.\r\n\r\nExample: \"Bearer eyJhBslkKLIIDJDMSNsdsk\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});




builder.Services.AddPersistenceRegistration(builder.Configuration);//persistence layerinin serviceRegistrationu
builder.Services.AddApplicationRegistration();
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddCustomMapperRegistration();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();//custom exception middleware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
