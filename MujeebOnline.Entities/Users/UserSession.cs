

namespace MujeebOnline.Entities
{
    public class UserSession 
    {
 
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsCancelled { get; set; }
        public string Mydetails1 { get; set; }
        public string Mydetails2 { get; set; }
        public Guid UserRequestID { get; set;}
    }
}
