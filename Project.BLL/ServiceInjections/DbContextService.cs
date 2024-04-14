using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            //Neden ServiceProvider

            //Cünkü biz bu noktada aslında bir Core.MVC platformundaki startup dosyasında degiliz...Dolayısıyla oradaki hazır service elimizde yok...Biz o yapıları ayaga kaldırmak adına bir giriş noktasına ihtiyac duyarız...Ve bu giriş noktasını bana ServiceProvider nesnesi saglar...


            IConfiguration? configuration = provider.GetService<IConfiguration>();
            //Neden IConfiguration

            //IConfiguration sayesinde projenizin conf.(ayarlamalarının) bulundugu dosyaya ulasabiliyorsunuz...

            services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
            //DbContextPool'umuz böylece StartUp'da DAL'den bir sınıfı kullanmaktan ziyade sadece BLL'deki bu yaratılmıs olan class'ın kurallarıyla bir Service entregrasyonu yapacaktır...

            return services;
        }
    }
}
