using Project_Krekelhof.Models.DAL;
using Project_Krekelhof.Models.Domain;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Project_Krekelhof.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Project_Krekelhof.App_Start.NinjectWebCommon), "Stop")]

namespace Project_Krekelhof.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IItemRepository>().To<ItemRepository>().InRequestScope();
            kernel.Bind<IBoekRepository>().To<BoekRepository>().InRequestScope();
            kernel.Bind<ICdRepository>().To<CdRepository>().InRequestScope();
            kernel.Bind<IDvdRepository>().To<DvdRepository>().InRequestScope();
            kernel.Bind<ISpelRepository>().To<SpelRepository>().InRequestScope();
            kernel.Bind<ICategorieRepository>().To<CategorieRepository>().InRequestScope();
            kernel.Bind<ILeerlingRepository>().To<LeerlingRepository>().InRequestScope();
            kernel.Bind<IUitleningRepository>().To<UitleningRepository>().InRequestScope();
            kernel.Bind<KrekelschoolContext>().ToSelf().InRequestScope();
        }        
    }
}
