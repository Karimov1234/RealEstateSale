using Application.Abstractions.IEntityRepositories;
using Application.Abstractions.IRepositories;
using Application.Abstractions.IServices;
using Application.Abstractions.IUnitOfWorks;
using Application.Mapps;
using Domain.Entities.Identities;
using FluentValidation.AspNetCore;
using FluentValidation;
using Infrastructure.Implementations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistance;
using Persistance.Implementations.EntityRepositories;
using Persistance.Implementations.Repositories;
using Persistance.Implementations.Services;
using Persistance.Implementations.UnitOfWork;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Application.Extensions;
using Application.Validators.RegionOfCityValidator;
using Microsoft.AspNetCore.Identity;
using Application.Validators.AgentValidators;
using Application.DTOs.AgentDtos;
using Application.DTOs.ImageDtos;
using Application.Validators.ImageValidators;
using Application.DTOs.OwnerDtos;
using Application.Validators.OwnerValidator;
using Application.DTOs.ReviewDtos;
using Application.Validators.ReviewValidators;
using Application.DTOs.UserDtos;
using Application.Validators.UserValidator;
using Application.DTOs.PropertyDtos;
using Application.Validators.PropertyValidator;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

// Add services to the container.
builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,//tokunumuzu kim/hansi origin islede biler
        ValidateIssuer = true, //tokunu kim palylayir
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true, //tokenin ozel keyi

        ValidAudience = builder.Configuration["JWT:Audience"],

        ValidIssuer = builder.Configuration["JWT:Issuer"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),

        //token omru qeder islemesi ucun
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

        NameClaimType = ClaimTypes.Name,
        RoleClaimType = ClaimTypes.Role
    };
});
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation  
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EstateSale API",
        Description = "ASP.NET Core 6 Web API"
    });
    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

//builder.Services.UseCustomValidationResponse();
var conf = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conf));

//service
builder.Services.AddAutoMapper(typeof(MapingProfile).Assembly);
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<ITokenHandler, Persistance.Implementations.TokenHandler>();
builder.Services.AddScoped<IAuthService, AuthService>();
//repositiries
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
//validators
builder.Services.AddScoped<IValidator<CreateUpdateAgentDTO>, AgentCreateUpdateDTOValidator>();
builder.Services.AddScoped<IValidator<CreateUpdateImageDTO>, CreateUpdateImageDTOValidator>();
builder.Services.AddScoped<IValidator<CreatePropertyDTO>, CreatePropertyDTOValidator>();
builder.Services.AddScoped<IValidator<UpdatePropertyDTO>, UpdatePropertyDTOValidator>();
builder.Services.AddScoped<IValidator<GetPropertyDTO>, GetPropertyDTOValidator>();
builder.Services.AddScoped<IValidator<CreateUpdateOwnerDTO>, CreateUpdateOwnerDTOValidator>();
builder.Services.AddScoped<IValidator<ReviewCreateDTO>, ReviewCreateDTOValidator>();
builder.Services.AddScoped<IValidator<ReviewUpdateDTO>, ReviewUpdateDTOValidator>();
builder.Services.AddScoped<IValidator<CreateUserDTO>, CreateUserDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateUserDTO>, UpdateUserDTOValidator>();



Logger log = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Debug)
    .WriteTo.File("Logs/myJsonLogs.json")
    .WriteTo.File("logs/mylogs.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

Log.Logger = log;
builder.Host.UseSerilog(log);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureExtentionHandler();
app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();