using System.Reflection;
using Library.MVC.Contracts;
using Library.MVC.Services;
using Library.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLiveReload(cfg =>
{
    cfg.LiveReloadEnabled = true;
    cfg.FolderToMonitor = builder.Environment.WebRootPath;
    cfg.ServerRefreshTimeout = 1;
});

builder.Services.AddMvc(x =>
{
    x.EnableEndpointRouting = true;
})
    .AddViewOptions(x =>
    {
        x.HtmlHelperOptions.ClientValidationEnabled = true;
    });



builder.Services.AddMemoryCache();
builder.Services.AddSession();
 builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5020"));
 builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

 builder.Services.AddTransient<ILoginService, LoginService>();
 builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFinePaymentService, FinePaymentService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IShelfService, ShelfService>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddControllersWithViews(x =>
{
    x.ModelMetadataDetailsProviders.Add(new NewtonsoftJsonValidationMetadataProvider());
}).AddNewtonsoftJson();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseLiveReload();
app.UseRouting();
app.UseSession();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();