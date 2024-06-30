using System.Reflection;
using Ardalis.ListStartupServices;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ContributorAggregate;
using Salpat.Clientes.Core.Interfaces;
using Salpat.Clientes.Infrastructure;
using Salpat.Clientes.Infrastructure.Data;
using Salpat.Clientes.Infrastructure.Email;
using Salpat.Clientes.UseCases.Contributors.Create;
using Salpat.Clientes.Web.Components;
using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;
using Serilog;
using Serilog.Extensions.Logging;
using Radzen;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Salpat.Clientes.Web;
using System.IdentityModel.Tokens.Jwt;


const string MS_OIDC_SCHEME = "MicrosoftOidc";
var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddAuthentication(MS_OIDC_SCHEME)
.AddOpenIdConnect(MS_OIDC_SCHEME, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:7001/";
    options.ClientId = "polaris_cv";
    options.ClientSecret = "CON030626vol@";
    options.ResponseType = "code";
    //options.SaveTokens = true;
    //options.GetClaimsFromUserInfoEndpoint = true;
    //options.UseTokenLifetime = false;
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //options.TokenValidationParameters = new TokenValidationParameters{ NameClaimType = "name" };
    // options.CallbackPath = new PathString("/signin-oidc");
    // options.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
    // options.RemoteSignOutPath = new PathString("/signout-oidc");
    options.MapInboundClaims = false;
    options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
    options.TokenValidationParameters.RoleClaimType = "role";

    options.Events = new OpenIdConnectEvents
    {
        OnAccessDenied = context =>
        {
            context.HandleResponse();
            context.Response.Redirect("/");
            return Task.CompletedTask;
        }
    };
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.ConfigureCookieOidcRefresh(CookieAuthenticationDefaults.AuthenticationScheme, MS_OIDC_SCHEME);

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents()
  .AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024);
builder.Services.AddControllers();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpClient();



// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                });

ConfigureMediatR();

builder.Services.AddInfrastructureServices(builder.Configuration, microsoftLogger);

if (builder.Environment.IsDevelopment())
{
  // Use a local test email server
  // See: https://ardalis.com/configuring-a-local-test-email-server/
  builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();

  // Otherwise use this:
  //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();
  AddShowAllServicesSupport();
}
else
{
  builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
  app.UseDefaultExceptionHandler(); // from FastEndpoints
  app.UseHsts();
}

app.UseFastEndpoints()
    .UseSwaggerGen(); // Includes AddFileServer and static files middleware

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapGroup("/authentication").MapLoginAndLogout();

SeedDatabase(app);

app.Run();

static void SeedDatabase(WebApplication app)
{
  using var scope = app.Services.CreateScope();
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    //          context.Database.Migrate();
    context.Database.EnsureCreated();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

void ConfigureMediatR()
{
  var mediatRAssemblies = new[]
{
  Assembly.GetAssembly(typeof(Contributor)), // Core
  Assembly.GetAssembly(typeof(CreateContributorCommand)) // UseCases
};
  builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
  builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
  builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

void AddShowAllServicesSupport()
{
  // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
  builder.Services.Configure<ServiceConfig>(config =>
  {
    config.Services = new List<ServiceDescriptor>(builder.Services);

    // optional - default path to view services is /listallservices - recommended to choose your own path
    config.Path = "/listservices";
  });
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
