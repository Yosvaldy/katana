using System.Web.Http;

namespace Katana
{
    public class GreetingsController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting { Text = "Hello World from API..." };
        }
    }
}
