using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<GetProductQueryHandler>();// her bir handler? bir scop olarak  yani uygulama �al??t???nda bir kere olu?sun ve olu?tuktan sonra tekrar kullanabilelim
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<GetProductByIDQueryHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();
builder.Services.AddScoped<GetProductUpdateByIDQueryHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();

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
