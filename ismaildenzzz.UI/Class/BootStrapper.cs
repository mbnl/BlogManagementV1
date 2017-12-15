using Autofac;
using Autofac.Integration.Mvc;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.UI.Class
{
    public class BootStrapper
    {
        public static void RunConfig()
        {
            BuildAutoFac();
        }
        //boot aşamasında çalışacak.
        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AdminRepository>().As<IAdminRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();
            builder.RegisterType<EtiketRepository>().As<IEtiketRepository>();
            builder.RegisterType<IletisimRepository>().As<ILetisimRepository>();
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterType<YorumRepository>().As<IYorumRepository>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            /*
             Core katmanındaki interface lerimiz burada register edilecek. 
             */

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}