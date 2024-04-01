using chainOfResponsibilty.pipline.API;
using chainOfResponsibilty.pipline.Application;
using chainOfResponsibilty.pipline.Domaine.Services;
using chainOfResponsibilty.pipline.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPaymentManager,PaymentManager>();
builder.Services.AddSingleton<IMachineManager,MachineManager>();
builder.Services.AddSingleton<DataStore>();
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

app.UseAuthorization();

app.MapControllers();

app.UseLaundryRequest();

app.Run( async context =>
{
    await context.Response.StartAsync();
});
app.Run();






