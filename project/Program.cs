using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.Models.RegistrationModels.Domain;
using project.Repositories.Abstruct;
using project.Repositories.Impl;
using project.Models.ProductModels.Domain;
using project.Repositories.BankSystem.Abstruct;
using project.Repositories.BankSystem.impl;
using project.Repositories.BankSystem.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddDbContext<BankingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddDbContext<BankDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddDbContext<MyBankDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);



//for Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/Login/Login");

builder.Services.AddScoped<UserAuthenticationService,UserAuthenticationServiceImpl>();
builder.Services.AddScoped<ProductService,ProductServiceImpl>();
builder.Services.AddScoped<ReportService,ReportServiceImpl>();
builder.Services.AddScoped<SmtpService,SmtpServiceImpl>();
builder.Services.AddScoped<PaymentService,PaymentServiceImpl>();
builder.Services.AddScoped<BankingInterface,BankingInterfaceImpl>();
builder.Services.AddScoped<VisaService, VisaServiceImpl>();
builder.Services.AddScoped<MasterService, MasterServiceImpl>();



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
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Home}/{action=Index}/{PageNumber}/{operation}"
    );
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Admin}/{action=ManageUsers}/{PageNumber}/{operation}"
    );
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Admin}/{action=ApprouveUser}/{UserName}"
    );
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Admin}/{action=DeleteUser}/{UserName}"
    );
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Admin}/{action=ApproveProduct}/{ProductId}"
    );
app.MapControllerRoute(
    name: "Pagination",
    pattern: "{controller=Admin}/{action=DeleteProduct}/{ProductId}"
    );

app.Run();
