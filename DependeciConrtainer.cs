using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketBook.Core.IConfiguration;
using TamsaApi.Data;
using TamsaApi.ViewModels;

namespace TamsaApi
{
    public static class DependeciConrtainer
    {
        public static void setServeses(IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<KaveNegarModel>(configuration.GetSection("KaveNegar:Api"));///baraye dastreci be maqadire apppseting.json az Configurstion estefade mikonim 
            services.Configure<PassarGadModel>(configuration.GetSection("PassarGad:SeryalNumber"));
            ////ervices.AddScoped<IuserReposetory,userReposetory>();    
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        
        }
    }
}  