using BlazorWebApi.Infrastructure.Data;
using BlazorWebApi.Application.Services;
using BlazorWebApi.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.InfraStructure.Repository;
using BlazorWebApi.Server.Properties;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVillaService, VillaService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMessagesService, MessagesService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<ILoginLogService, LoginLogService>();
builder.Services.AddScoped<IGiftCartService, GiftCartService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
//builder.Services.AddScoped<IAdminLogService, AdminLogService>();
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Host.UseSerilog((hb, lc) => lc.ReadFrom.Configuration(hb.Configuration));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// تنظیمات Auth
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)) // کلید امضاء
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(optyion =>
{
    optyion.AddPolicy("BlazorWasm", policy =>
    {
        policy.WithOrigins("https://localhost:6170")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSerilogIngestion();
app.UseSerilogRequestLogging();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseCors("BlazorWasm");
app.UseCors("AllowMauiApp");
app.UseCors("AllowAll");
app.Run();
