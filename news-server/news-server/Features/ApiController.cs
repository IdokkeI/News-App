using Microsoft.AspNetCore.Mvc;

namespace news_server.Features
{
    [ApiController]
    [Route("[controller]")] 
    public abstract class ApiController: ControllerBase
    {
    }
}
