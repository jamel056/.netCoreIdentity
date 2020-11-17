using Microsoft.AspNetCore.Mvc;
using NetCoreIdentity.Data.Const;
using NetCoreIdentity.Repositories;

namespace NetCoreIdentity.Controllers
{
    [Route(Routes.Base)]
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
