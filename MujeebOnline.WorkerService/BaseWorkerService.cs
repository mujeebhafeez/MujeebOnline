using MujeebOnline.Business;
using MujeebOnline.Repositories;

namespace MujeebOnline.WorkerService
{
    public abstract class BaseWorkerService : BackgroundService
    {
        protected readonly IServiceProvider ServiceProvider;
        public IRepositoryServiceProvider GetRepositoryProvider()
        {
            return new RepositoryServiceProvider();
        }
        public IBusinessProvider GetBusinessProvider()
        {
            IRepositoryServiceProvider repositoryServiceProvider = new RepositoryServiceProvider();
            return new BusinessProvider(repositoryServiceProvider);
        }
    }
}
