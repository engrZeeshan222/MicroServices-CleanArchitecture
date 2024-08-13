using Clean.Application.Dtos;
using Clean.Application.Interface;
using Clean.Application.Services.Auths;
using Clean.Application.Services.Roles;
using Clean.Application.Services.Stripes;
using Clean.Application.Services.Users;
using Clean.Infrastructure;
using Clean.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure CORS (Cross-Origin Resource Sharing) to allow requests from any origin,
// with any headers, and using any HTTP method.
//builder.Services.AddCors(options =>
//{
//    // Add a default CORS policy with unrestricted access.
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            // Allow requests from any origin.
//            builder.AllowAnyOrigin()
//            // Allow requests with any headers.
//            .AllowAnyHeader()
//            // Allow requests using any HTTP method.
//            .AllowAnyMethod();
//        });
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["JWTSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:SecretKey"]))
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFileOrigin", builder =>
    {
        builder.WithOrigins("file:///D:/My%20Projects/Stripe_CheckOut/StripePage.html")
                .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<TokenService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<ChargeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStripeRepository, StripeRepository>();
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFileOrigin");
app.UseHttpsRedirection();
StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
