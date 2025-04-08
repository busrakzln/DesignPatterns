using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.BusinessLayer.Concrete;
using DesignPattern.DataAccessLayer.Abstratc;
using DesignPattern.DataAccessLayer.Concrete;
using DesignPattern.DataAccessLayer.EntityFramework;
using DesignPattern.DataAccessLayer.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ICustomerDal,EfCustomerDal>();   
builder.Services.AddScoped<ICustomerService,CustomerManager>();
builder.Services.AddScoped<IUowDal,UowDal>();
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
