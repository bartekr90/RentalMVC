using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalMVC.Application.Extensions;
using RentalMVC.Infrastructure;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(configuration)
  .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<Context>();
    builder.Services.AddControllersWithViews();

    //builder.Services.AddAuthorization(options => 
    //{
    //    options.AddPolicy("EditRolePolicy", 
    //        policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));
    //});

    //builder.Services.AddTransient<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
    //builder.Services.AddTransient<IAuthorizationHandler, SuperAdminHandler>();
    //custome handlery

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Error");
        app.UseHsts();
        // The default HSTS value is 30 days. You may want to change this for production scenarios,
        // see https://aka.ms/aspnetcore-hsts.
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseSerilogRequestLogging();

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    Log.Information("Application starting up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "App fail to startup");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
return 0;