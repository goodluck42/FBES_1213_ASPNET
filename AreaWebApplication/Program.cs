var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();


app.MapControllerRoute
(
	name: "default1",
	pattern: "Student/{controller}/{action}/",
	defaults: new
	{
		controller = "Main",
		action = "Index"
	}
);

app.MapControllerRoute
(
	name: "default",
	pattern: "{area}/{controller}/{action}/",
	defaults: new
	{
		area = "Student",
		controller = "Main",
		action = "Index"
	}
);



app.Run();
