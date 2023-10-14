using System.Globalization

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllerWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPages();
app.UseStatusCodePages();

app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    CultureInfo.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
    CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;

    await next.Invoke();
});

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
