

namespace MujeebOnline.Entities
{
    public interface IUserSession
    {
        public int UserID { get; }
        public string UserName { get; }
        public string UserPassword { get; }
        public bool IsCancelled { get; }
        public string Mydetails1 { get; }
        public string Mydetails2 { get; }
    }
}
