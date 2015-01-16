using System.Web.Http;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;

namespace NumberToWord.Common
{
    public class FrameworkStarter
    {
        public static void RegisterDependencies(IKernel kernel)
        {
            kernel.Bind<INumberToWordService<decimal>>().To<DecimalToEnglishConverter>().InRequestScope();
        }
    }
}
