using unit_converter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddSingleton<CalculateService>();

var app = builder.Build();

app.UseHttpsRedirection();

var fileOptions = new DefaultFilesOptions();
fileOptions.DefaultFileNames.Clear();
fileOptions.DefaultFileNames.Add("length.html");

app.UseDefaultFiles(fileOptions);
app.UseStaticFiles();

app.UseCors();

app.MapControllers();

app.Run();