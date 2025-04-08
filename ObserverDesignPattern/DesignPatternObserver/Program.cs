using DesignPatternObserver.DAL;
using DesignPatternObserver.ObserverPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        options.Password.RequireDigit = true; // ?ifre içinde rakam zorunlu
        options.Password.RequiredLength = 8; // Minimum ?ifre uzunlu?u
        options.Password.RequireNonAlphanumeric = false; // Özel karakter zorunlu de?il
        options.Password.RequireUppercase = true; // Büyük harf zorunlu
        options.Password.RequireLowercase = true; // Küçük harf zorunlu
    }
    ).AddEntityFrameworkStores<Context>(); // ?dentity yap?land?rma komutlar?

builder.Services.AddSingleton<ObserverObject>(sp =>
{
    ObserverObject observerObject = new();
    observerObject.RegisterObserver(new CreateWelcomeMessage(sp));
    observerObject.RegisterObserver(new CreateMagazineAnnocuncement(sp));
    observerObject.RegisterObserver(new CreateDiscountCode(sp));
    return observerObject;
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
