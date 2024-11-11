using BlazorWebApi.Infrastructure.Data;
using BlazorWebApi.Application.Services;
using BlazorWebApi.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.InfraStructure.Repository;

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
builder.Services.AddScoped<IAdminLogService, AdminLogService>();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Host.UseSerilog((hb, lc) => lc.ReadFrom.Configuration(hb.Configuration));

builder.Services.AddCors(optyion =>
{
    optyion.AddPolicy("BlazorWasm", policy =>
    {
        policy.WithOrigins("https://localhost:6170")
            .AllowAnyHeader()
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
