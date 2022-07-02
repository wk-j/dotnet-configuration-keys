using KeysConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddKeysConfiguration(sectionName: "Keys");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ShowConfig();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
