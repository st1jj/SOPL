using Microsoft.EntityFrameworkCore;
using SOPL.Web;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SdOPLDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoplDatabase")));

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.Authority = "https://localhost:5001"; // serwer autoryzacji
//        options.Audience = "sopl_api";
//    });
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
