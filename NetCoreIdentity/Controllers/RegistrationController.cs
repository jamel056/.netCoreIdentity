﻿using Microsoft.AspNetCore.Mvc;
using NetCoreIdentity.Data.Const;
using NetCoreIdentity.DTO;
using NetCoreIdentity.Repositories;
using NetCoreIdentity.Requests;
using System.Threading.Tasks;

namespace NetCoreIdentity.Controllers
{
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        // by using postman set the url https://localhost:5001/api/v1/registration/{guidOfOneUser}
        [HttpGet]
        [Route(Routes.Registration.Get)]

        public async Task<IActionResult> GetUser(string id)
        {
            var userFromDb = await _registrationRepository.GetUser(id);
            if (userFromDb == null)
                return NotFound();

            return Ok(new UserDTO(userFromDb));
        }

        // https://localhost:5001/api/v1/registration/create   with a body(request) information of user
        [Route(Routes.Registration.Create)]
        [HttpPost]
        public async Task<IActionResult> CreateUser(ApplicationUserRequest request)
        {
            var isCreated = await _registrationRepository.RegisterUser(request);

            return Ok(isCreated);
        }

        // https://localhost:5001/api/v1/registration/{guidOfOneUser}    with a body(request) information of user u want to edit
        [Route(Routes.Registration.Edit)]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserRequest request, string id)
        {
            var isUpdated = await _registrationRepository.EditUser(request, id);

            return Ok(isUpdated);
        }

        // https://localhost:5001/api/v1/registration/{guidOfOneUser}
        [Route(Routes.Registration.Delete)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var userFromDb = await _registrationRepository.GetUser(id);
            if (userFromDb == null)
                return NotFound();

            var isDeleted = await _registrationRepository.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}
