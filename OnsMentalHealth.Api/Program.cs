using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnsMentalHealth.BLL.Manager;
using OnsMentalHealth.BLL.Manager.AccountsManager;
using OnsMentalHealth.BLL.Manager.BlogsManager;
using OnsMentalHealth.BLL.Manager.CommentsManager;
using OnsMentalHealth.BLL.Mapping;
using OnsMentalHealth.BLL.Services;
using OnsMentalHealth.DAl.Reposatory;
using OnsMentalHealth.DAl.Reposatory.BlogsRepo;
using OnsMentalHealth.DAl.Reposatory.Comments;
using OnsMentalHealth.DAl.Repositories;
using OnsMentalHealth.DAL.Repository;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITherapistRepo, TherapistRepo>();


builder.Services.AddScoped<ITherapistManager, TherapistManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IBlogsRepo, BlogsRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();

builder.Services.AddScoped<IBookingManager, BookingManager>();
builder.Services.AddScoped<IBlogManager, BlogManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<IAccountManager, AccountManager>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<OnsDbContext>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings.GetValue<string>("SecretKey");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
            ValidAudience = jwtSettings.GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "OnsMentalHealth API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter JWT token like: Bearer {your token}"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
