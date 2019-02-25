using Ninject;
using Ninject.Extensions.Wcf;
using System.ServiceModel;

namespace Interchange.WCF
{
    public class NinjectFileLessServiceHostFactory : NinjectServiceHostFactory
    {
        public NinjectFileLessServiceHostFactory()
        {
            var kernel = new StandardKernel(new NinjectServiceModule());
            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            SetKernel(kernel);
        }
    }
}