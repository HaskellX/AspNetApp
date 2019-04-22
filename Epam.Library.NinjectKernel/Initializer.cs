using BL_Contracts;
using BL_Contracts.Logic;
using BL_Contracts.Validator;
using BlContracts;
using BlContracts.Logic;
using BlContracts.Validator;
using Business_Logic_Layer.Logic;
using Business_Logic_Layer.Validator;
using BusinessLogicLayer.Logic;
using BusinessLogicLayer.Validator;
using DAL_Contracts;
using DalContracts;
using Epam.Library.SqlDal;
using log4net;
using Ninject;

namespace Epam.Library.NinjectKernel
{
    public static class Initializer
    {
        private static IKernel kernel;

        public static IKernel Kernel
        {
            get
            {
                return Initializer.kernel;
            }
        }

        static Initializer()
        {
            kernel = new StandardKernel();

            kernel.Bind<IAuthorDAO>().To<AuthorDAO>().InSingletonScope();
            kernel.Bind<IBookDAO>().To<BookDAO>().InSingletonScope();
            kernel.Bind<IPaperDAO>().To<PaperDAO>().InSingletonScope();
            kernel.Bind<IPatentDAO>().To<PatentDAO>().InSingletonScope();
            kernel.Bind<IPublisherDAO>().To<PublisherDAO>().InSingletonScope();
            kernel.Bind<IFilteredDAO>().To<FilteredDAO>().InSingletonScope();
            kernel.Bind<ICommonDAO>().To<CommonDAO>().InSingletonScope();
            kernel.Bind<IPaperIssueDAO>().To<PaperIssueDAO>().InSingletonScope();
            kernel.Bind<IUserDao>().To<UserDao>().InSingletonScope();

            kernel.Bind<IAuthorLogic>().To<AuthorLogic>().InSingletonScope();
            kernel.Bind<IBookLogic>().To<BookLogic>().InSingletonScope();
            kernel.Bind<IPaperLogic>().To<PaperLogic>().InSingletonScope();
            kernel.Bind<IPatentLogic>().To<PatentLogic>().InSingletonScope();
            kernel.Bind<ICommonAccess>().To<CommonAccess>().InSingletonScope();
            kernel.Bind<IPublisherLogic>().To<PublisherLogic>().InSingletonScope();
            kernel.Bind<IPaperIssueLogic>().To<PaperIssueLogic>().InSingletonScope();
            kernel.Bind<IUserLogic>().To<UserLogic>().InSingletonScope();


            kernel.Bind<IAuthorValidator>().To<AuthorValidator>().InSingletonScope();
            kernel.Bind<IBookValidator>().To<BookValidator>().InSingletonScope();
            kernel.Bind<IPublisherValidator>().To<PublisherValidator>().InSingletonScope();
            kernel.Bind<IPaperIssueValidator>().To<PaperIssueValidator>().InSingletonScope();
            kernel.Bind<IPaperValidator>().To<PaperValidator>().InSingletonScope();
            kernel.Bind<IPatentValidator>().To<PatentValidator>().InSingletonScope();

            kernel.Bind<ILogger>().To<Logger.Logger>().InSingletonScope();
            kernel.Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.ParentContext.Plan.Type));

        }

        public static ICommonAccess CommonAccessLogic
        {
            get
            {
                return kernel.Get<ICommonAccess>();
            }
        }


    }
}