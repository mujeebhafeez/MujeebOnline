
namespace MujeebOnline.Connector
{
    public class ExternalServiceProvider : IExternalServiceProvider
    {

        private MyMessageBuilder _myMessageBuilder;


        public MyMessageBuilder MyMessageBuilder => _myMessageBuilder ??= new MyMessageBuilder();
    }
}
