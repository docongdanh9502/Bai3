var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC và Session
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Sử dụng các middleware cần thiết
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Student}/{action=Index}/{id?}");
});

app.Run();
