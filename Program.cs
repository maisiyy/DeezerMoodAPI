var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<SpotifyMoodAPI.Services.DeezerService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseDefaultFiles();  // ← tambah ni BEFORE UseStaticFiles
app.UseStaticFiles();
app.MapControllers();
app.Run();

