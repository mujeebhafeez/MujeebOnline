using MujeebOnline.Repositories;

namespace MujeebOnline.Repositories
{
    public interface IRepositoryServiceProvider
    {
        public EmployeeRepository EmployeeRepository { get; }
        public UsersRepository UsersRepository { get; }
    }
}
