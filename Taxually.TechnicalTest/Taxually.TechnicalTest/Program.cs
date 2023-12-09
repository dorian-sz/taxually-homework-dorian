using Taxually.TechnicalTest.Helpers.Classes.CsvBuilder;
using Taxually.TechnicalTest.Helpers.Classes.HttpClient;
using Taxually.TechnicalTest.Helpers.Classes.QueueClient;
using Taxually.TechnicalTest.Helpers.Classes.VatModelChecker;
using Taxually.TechnicalTest.Helpers.Classes.VatRegistration;
using Taxually.TechnicalTest.Helpers.Classes.VatRegistrationFactory;
using Taxually.TechnicalTest.Helpers.Classes.XmlBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.CsvBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.HttpClient;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistrationFactory;
using Taxually.TechnicalTest.Helpers.Interfaces.XmlBuilder;
using Taxually.TechnicalTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVatRegistration<VatRegistrationModel>, GbVatRegistration>();
builder.Services.AddScoped<IVatRegistration<VatRegistrationModel>, FrVatRegistration>();
builder.Services.AddScoped<IVatRegistration<VatRegistrationModel>, DeVatRegistration>();
builder.Services.AddScoped<IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>>, VatRegistrationFactory>();
builder.Services.AddTransient<ITaxuallyHttpClient<VatRegistrationModel>, TaxuallyHttpClient>();
builder.Services.AddTransient<ITaxuallyQueueClient<byte[]>, CsvTaxuallyQueueClient>();
builder.Services.AddTransient<ITaxuallyQueueClient<string>, XmlTaxuallyQueueClient>();
builder.Services.AddTransient<ICsvBuilder, CsvBuilder>();
builder.Services.AddTransient<IXmlBuilder<VatRegistrationModel>, XmlBuilder>();
builder.Services.AddTransient<IModelPropertyChecker<VatRegistrationModel>, VatModelChecker>();

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

app.Run();
