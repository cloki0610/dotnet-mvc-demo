using Microsoft.EntityFrameworkCore;
using dotnet_mvc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcBlogContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcBlogContext")
        ?? throw new InvalidOperationException("Connection string 'MvcBlogContext' not found.")));
}
else
{
    builder.Services.AddDbContext<MvcBlogContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcBlogContext")
        ?? throw new InvalidOperationException("Connection string 'ProductionMvcBlogContext' not found.")));
}

builder.Services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>().AddEntityFrameworkStores<MvcBlogContext>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
