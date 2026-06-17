using DotNetEnv;
using SearchingForItems.Data;
using SearchingForItems.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<LocationRepository>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<ApiService>();

builder.Services.AddDistributedMemoryCache(); // Для хранения сессий в памяти
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
