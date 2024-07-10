using CreditBusinessLayer.Services.Abstractions;
using CreditBusinessLayer.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CreditBusinessLayer.Extensions
{
	public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IGuarantorService, GuarantorService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddTransient<ILoanCalculatorService, LoanCalculatorService>();

            return services;
        }
    }
}
