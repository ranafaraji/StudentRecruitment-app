using Microsoft.EntityFrameworkCore;
using StudentRecuitmentProject.DBmodels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentRecuitmentProjectDbContext>(options =>
{
    options.UseSqlServer("Data Source=.; Initial Catalog=StudentRecruitment; Integrated Security=True; TrustServerCertificate=true");
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
