

using MongoDbWebApplication.RouteConstraints;

var builder = WebApplication.CreateBuilder(args);
var VadimPolicy = "__VadimPolicy__";

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.ConstraintMap.Add("objectid", typeof(ObjectIdRouteConstraint));
});

builder.Services.AddCors(config =>
{
    config.AddPolicy(VadimPolicy, policy =>
    {
        //policy.WithOrigins("https://www.google.com/").AllowAnyHeader().AllowAnyMethod();
        // Same-Origin
        // https://www.google.com/
        // NOT SAME ORIGIN
        // http://www.google.com/
        // https://accounts.google.com/
        // https://accounts.google.net/
        // https://accounts.google.net:334

        policy.WithOrigins("https://www.google.com").AllowAnyHeader().WithMethods(HttpMethods.Get);
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
