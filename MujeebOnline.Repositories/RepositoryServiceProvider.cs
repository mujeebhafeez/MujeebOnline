namespace MujeebOnline.Repositories
{
    public class RepositoryServiceProvider : IRepositoryServiceProvider
    {

        private EmployeeRepository _employeeRepository;
        private UsersRepository _usersRepository;


        public EmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(this);
        public UsersRepository UsersRepository => _usersRepository ??= new UsersRepository(this);
    }







}
