namespace MujeebOnline.Entities
{
    public class SessionManager : ISessionManager
    {
        /*
        private UserSession _myUserSession;
        public UserSession MyUserSession { get => _myUserSession ?? new UserSession(); set => { _myUserSession = value; } }
        */
        public UserSession MyUserSession { get; set; }
    }
}
