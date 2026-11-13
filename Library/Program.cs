 midterm
using library.Data;
using Npgsql;

using Npgsql;
using library.Data;
 master

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC services to the container.
builder.Services.AddControllersWithViews();

// 2. Database: Read the connection string from User Secrets and create one shared data source.
var connectionString = builder.Configuration.GetConnectionString("Library");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'Library' is missing. Add it in Manage User Secrets.");
}

var dataSource = NpgsqlDataSource.Create(connectionString);
builder.Services.AddSingleton(dataSource);

// 3. Repositories: Register all application repositories (one new object per web request).
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<MemberRepository>();



// Database connection string & data source
var connectionString = builder.Configuration.GetConnectionString("Library");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'Library' is missing.");
}
var dataSource = NpgsqlDataSource.Create(connectionString);
builder.Services.AddSingleton(dataSource);

// Register NoteRepository only
builder.Services.AddScoped<NoteRepository>();

var app = builder.Build();

// 4. Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
