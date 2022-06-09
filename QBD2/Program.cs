using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using Blazored.Toast;
using QBD2.Services;
using Microsoft.AspNetCore.Authentication;
using Hangfire;
using Hangfire.SqlServer;
using QBD2.Models;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var sageConnection = builder.Configuration.GetConnectionString("Sage300Connection");
builder.Services.AddDbContext<Sage300Context>(options => options.UseSqlServer(sageConnection));

builder.Services.Configure<ApplicationSettings>(configuration.GetSection("Settings"));

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTelerikBlazor();
builder.Services.AddBlazoredToast();

#region Services

builder.Services.AddScoped<ProductFamilyService>();
builder.Services.AddScoped<MasterPartService>();
builder.Services.AddScoped<StationService>();
builder.Services.AddScoped<ExcelUploadService>();
builder.Services.AddScoped<PartService>();
builder.Services.AddScoped<InspectionService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DeviationService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<SerialNumberService>();
builder.Services.AddScoped<BlobService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<GLCodeService>();
builder.Services.AddScoped<FailureCodeService>();
builder.Services.AddScoped<PartStatusService>();
builder.Services.AddScoped<ApplicationSettings>();
builder.Services.AddScoped<RepairService>();
builder.Services.AddScoped<ScarCarImpactService>();
builder.Services.AddScoped<ScarCarProjectService>();
builder.Services.AddScoped<ScarCarCategoryService>();
builder.Services.AddScoped<ScarCarPriorityService>();
builder.Services.AddScoped<ScarCarStatusService>();
builder.Services.AddScoped<ScarCarResolutionService>();
builder.Services.AddScoped<IClaimsTransformation, ClaimsTransformer>();

#endregion

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

builder.Services.AddHangfireServer();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseHangfireDashboard("/hangfire");

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var myDependency = services.GetRequiredService<ItemService>();
    RecurringJob.AddOrUpdate("Sync Service : Runs Every 1 Min", () => myDependency.UpdateMasterParts(), "*/1 * * * *");
}

app.Run();
