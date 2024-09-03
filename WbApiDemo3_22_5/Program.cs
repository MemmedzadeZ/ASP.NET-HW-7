using Microsoft.EntityFrameworkCore;
using WbApiDemo3_22_5.Data;
using WbApiDemo3_22_5.Formatters;
using WbApiDemo3_22_5.Middlewares;
using WbApiDemo3_22_5.Repository.Abstract;
using WbApiDemo3_22_5.Repository.Concrete;
using WbApiDemo3_22_5.Services.Abstract;
using WbApiDemo3_22_5.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(0, new TextCsvOutputFormatter());
    options.InputFormatters.Insert(0,new TextCsvInputFormatter());  
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService,StudentService>();


var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
