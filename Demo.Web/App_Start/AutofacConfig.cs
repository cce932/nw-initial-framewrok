using Autofac;
using Autofac.Integration.Mvc;
using Demo.EntityFramework.Infrastructure;
using Demo.Repository;
using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web.App_Start
{
    /// <summary>
    ///     Autofac DI 注入設定
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        ///     註冊DI注入物件資料
        /// </summary>
        public static IContainer Register()
        {
            // 容器建立者
            var builder = new ContainerBuilder();
            // Get your HttpConfiguration.
            //var config = GlobalConfiguration.Configuration;

            // 註冊 Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // WebAPIs
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            RegisterDependency(builder);

            // 建立容器
            var container = builder.Build();

            // 建立相依解析器
            // Set Up MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Set Up WebAPI Resolver
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void RegisterDependency(ContainerBuilder builder)
        {
            // ConnectionString
            //var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // UnitOfWork
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // Repositories
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IRepository<,>));
            builder.RegisterAssemblyTypes(typeof(spt_monitorRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            // Services
            builder.RegisterAssemblyTypes(typeof(spt_monitorService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType<App_Code.Student>().As<App_Code.Student>();

            //// IOAuthAuthorizationServerProvider
            //builder.RegisterType<ApplicationOAuthProvider>().As<IOAuthAuthorizationServerProvider>().PropertiesAutowired().SingleInstance();

            // AutoMapper
            //var mapper = AutoMapperConfig.Configure();
            //builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
        }
    }
}