using MujeebOnline.Connector;
using MujeebOnline.Repositories;

namespace MujeebOnline.Business
{
    public class BusinessProvider : IBusinessProvider
    {
        private readonly IRepositoryServiceProvider _repositoryServiceProvider;
        private readonly IExternalServiceProvider _externalServiceProvider;

        private EmployeeBusiness _employeeBusiness;
        private UsersBusiness _usersBusiness;

        public BusinessProvider(IRepositoryServiceProvider repositoryServiceProvider,
            IExternalServiceProvider externalServiceProvider)
        {
            _repositoryServiceProvider = repositoryServiceProvider;
            _externalServiceProvider = externalServiceProvider;
        }


        public EmployeeBusiness EmployeeBusiness => _employeeBusiness ??= new EmployeeBusiness(this, _repositoryServiceProvider, _externalServiceProvider);
        public UsersBusiness UsersBusiness => _usersBusiness ??= new UsersBusiness(this, _repositoryServiceProvider, _externalServiceProvider);
    }
}
