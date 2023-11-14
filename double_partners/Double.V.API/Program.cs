using Double.V.API.Extensions;
using Double.V.Infraestructure.Database.DbProvider;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbProvider, DbProvider>();
builder.Services.AddJWT();
builder.Services.AddDB();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowCredentials().AllowAnyHeader();
    });
});
builder.Services.AddControllers(mvcOpts => {
    mvcOpts.SuppressAsyncSuffixInActionNames = false;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
