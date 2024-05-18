namespace MujeebOnline.Business
{
    public interface IBusinessProvider
    {
        public EmployeeBusiness EmployeeBusiness { get; }
        public UsersBusiness UsersBusiness { get; }
    }
}
