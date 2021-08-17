using KyivDigital.Business.Services.Implementations;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.MVC.Extensions;
using Microsoft.Extensions.DependencyInjection;
namespace KyivDigital.MVC.ServiceExtensions
{
    public static class KyivDigitalService
    {
        public static void AddKyivDigitalServices(this IServiceCollection services)
        {
            services.AddHttpClient<ITravelCardService, TravelCardService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IFeedService, FeedService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IEvacuationService, EvacuationService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IQrService, QrService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IPenaltiesService, PenaltiesService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IBankCardService, BankCardService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<ICarService, CarService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IParkingService, ParkingService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IGuessService, GuessService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IFaqService, FaqService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IKyivService, KyivService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IKyivEventService, KyivEventService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IHourlyParkingService, HourlyParkingServiceV4>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IOrderReceiptService, OrderReceiptService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IHeadLineService, HeadLineService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IPinDataService, PinDataService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IGBProjectService, GBProjectService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
        }
    }
}