using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

/*
public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

		})
			.AddCookie()
			.AddOpenIdConnect("Auth0", options =>
			{
				options.Authority = $"https://{Configuration["Auth0:Domain"]}";
				options.ClientId = Configuration["Auth0:CientId"];
				options.ClientSecret = Configuration["Auth0:ClientSecret"];
				options.ResponseType = OpenIdConnectResponseType.Code;
				options.Scope.Clear();
				options.Scope.Add("openid");
				options.CallbackPath = new PathString("/callback");
				options.ClaimsIssuer = "Auth0";
			});
		services.AddControllersWithViews();
	}
}

// Add services to the container.
/*
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
builder.Services.AddDbContext<AuthDbContext>(options =>
   options.UseSqlite(connectionString));


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//.AddEntityFrameworkStores<AuthDbContext>();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
	options.Domain = builder.Configuration["Auth0:dev-bmswr4gvkoigywp2.us.auth0.com"];
	options.ClientId = builder.Configuration["Auth0:6u8sdvYDBIo6zhwfaDU3eOHOsTmJX43h"];
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
	options.Conventions.AuthorizePage("/Account/Logout");
	options.Conventions.AuthorizePage("/MainForm/Forum");
	// Add more pages as needed
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
*/
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ForumDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ForumDbContextConnection' not found.");

builder.Services.AddDbContext<ForumDbContext>(options =>
	options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ForumDbContext>();

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
	options.Domain = builder.Configuration["Auth0:Domain"];
	options.ClientId = builder.Configuration["Auth0:ClientId"];
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
	options.Conventions.AuthorizePage("/Account/Logout");
	options.Conventions.AuthorizePage("/MainForm/Forum");
	//options.Conventions.AuthorizePage("/Index");
	// Add more pages as needed
});
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
