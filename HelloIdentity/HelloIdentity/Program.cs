using HelloIdentity.Data;
using HelloIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


builder.Services.AddAuthorization(opzioni =>
{
    opzioni.AddPolicy("NecessariaMatricolaETelefonoAziendale", policy =>
    {
        policy.RequireClaim("Matricola");
        policy.RequireClaim(ClaimTypes.MobilePhone);
    });
});


//var roleManager = builder.Services.BuildServiceProvider()
//     .GetService<RoleManager<IdentityRole>>();

//var userManager = builder.Services.BuildServiceProvider()
//    .GetService<UserManager<IdentityUser>>();

//var result = await GestioneUtenti.CreaRuolo(roleManager, "guest");
//result = await GestioneUtenti.AssegnaRuoloAdUtente(userManager, "mario.rossi@gmail.com", "guest");
//await GestioneUtenti.AggiungiClaimAUnUtente(userManager, "salvatore.sorrentino@live.com");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
