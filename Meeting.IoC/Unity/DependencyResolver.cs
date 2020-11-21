using Meeting.Domain.Interfaces.Services;
using Meeting.Infra.Persistence;
using prmToolkit.NotificationPattern;
using Meeting.Domain.Services;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Meeting.Domain.Interfaces.Repositories;
using Meeting.Infra.Persistence.Repositories;
using Meeting.Infra.Transaction;

namespace Meeting.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, MeetingContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceUser, ServiceUser>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceRoom, ServiceRoom>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceSchedule, ServiceSchedule>(new HierarchicalLifetimeManager());



            //Repository
            //container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryUser, RepositoryUser>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryRoom, RepositoryRoom>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorySchedule, RepositorSchedule>(new HierarchicalLifetimeManager());
        }
    }
}
