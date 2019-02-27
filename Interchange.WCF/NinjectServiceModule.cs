using Interchange.Data;
using Ninject.Modules;

namespace Interchange.WCF
{
    public class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<IFactory>().To<Factory>().WithConstructorArgument<AbstractFacade>(new AdoFacade());
            //this.Bind<IDbInternal>().To<DbInternal>().WithConstructorArgument<string>("DefaultConnectionString").WithConstructorArgument<AbstractFacade>(new AdoFacade());
        }
    }
}