using ContosoUniversity.Core.Data;
using ContosoUniversity.Core.Data.Entities;
using ContosoUniversity.Core.Lib.Services;
using ContosoUniversity.Core.Lib.Services.Impl;
using ContosoUniversity.Web.Lib.FormHandlers;
using Ninject;
using Ninject.Web.Common;

namespace ContosoUniversity.Web.Infrastructure
{
    public static class NinjectBootstrapper
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IStudentService>().To<StudentServiceImpl>().InRequestScope();
            kernel.Bind<IFormHandler<Student>>().To<StudentFormHandler>().InRequestScope();
        }
    }
}