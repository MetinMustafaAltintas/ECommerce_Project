using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            return services;

           /* Scoped Services: Bir Request'te Scope'un parammtre kümesinde aynı tipte birden fazla parametre olsa bile 1 instance üzerinden calısırsınız...Ancak bu Singleton degildir...Cünkü Request'in işi bittigi zaman garbage collector Ram'den o instance'i kaldırır...Bir Request'in scope'unda aynı tipte birden fazla instance repository'ler ve Manager'lar icin gerekli degildir...O yüzden Scoped tercih edilir... */
        }
    }
}
