using EA6Soap.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentService, StudentService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);  // Asegúrate de que la app escuche en el puerto 8080
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Configure SOAP endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IStudentService>(
        "/StudentService.asmx",
        new SoapEncoderOptions(),
        SoapSerializer.XmlSerializer,
        caseInsensitivePath: true);
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();