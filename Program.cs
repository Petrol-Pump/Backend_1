using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Security.Jwt;
using Petrol_Pump1.ModelPostgres;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FdwmrdjxContext>(options => options.UseNpgsql("Host=berry.db.elephantsql.com;Database=fdwmrdjx;Username=fdwmrdjx;Password=wPJzR6k6ZYtJJG5gIU4oQztRpjmCQKDr"));

/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

 
}).AddJwt*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
