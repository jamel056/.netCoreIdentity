using Microsoft.AspNetCore.Mvc;
using NetCoreIdentity.Repositories;

namespace NetCoreIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationRepository _registrationRepository;

        public RegistrationController(RegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


    }
}
