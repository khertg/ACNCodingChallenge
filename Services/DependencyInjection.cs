using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.MappingProfile;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<AccountTransactionProfile>();
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();

            return services;
        }
    }
}
