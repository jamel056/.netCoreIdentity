using Microsoft.AspNetCore.Identity;
using NetCoreIdentity.Models;
using NetCoreIdentity.Requests;
using System;
using System.Threading.Tasks;

namespace NetCoreIdentity.Repositories
{
    public interface IRegistrationRepository
    {
        Task<ApplicationUser> GetUser(string id);
        Task<bool> RegisterUser(ApplicationUserRequest request);
        Task<bool> EditUser(EditUserRequest request, string id);
        Task<bool> DeleteUser(string id);

        //************* Sign Methods *************
        Task<bool> LogIn(SignInRequest request);
        Task<bool> LogOut();

        //************* Roles Methods *************
        Task<bool> CreateRole(RoleRequest request);
        Task<bool> DeleteRole(RoleRequest request);
        Task<bool> AssignRoleToUser(UserRoleRequest request);
        Task<bool> RevokeRoleFromUser(UserRoleRequest request);

    }
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegistrationRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var userFromDb = await _userManager.FindByIdAsync(id);

            if (userFromDb == null) return false;

            var isDeleted = await _userManager.DeleteAsync(userFromDb);
            return isDeleted.Succeeded;
        }

        public async Task<bool> EditUser(EditUserRequest request, string id)
        {
            var userFromDb = await _userManager.FindByIdAsync(id);
            if (userFromDb == null) return false;

            // maping
            userFromDb.FirstName = request.FirstName;
            userFromDb.LastName = request.LastName;
            userFromDb.Age = request.Age;
            userFromDb.Sex = request.Sex;

            var isEditted = await _userManager.UpdateAsync(userFromDb);
            return isEditted.Succeeded;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> RegisterUser(ApplicationUserRequest request)
        {
            var user = request.GetModel();
            user.Id = Guid.NewGuid().ToString();

            var response = await _userManager.CreateAsync(user, request.Password);
            return response.Succeeded;
        }

        //************* Sign Methods *************
        public async Task<bool> LogIn(SignInRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> LogOut()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        //************* Roles Methods *************
        public async Task<bool> CreateRole(RoleRequest request)
        {
            IdentityRole newRole = new IdentityRole()
            {
                Name = request.RoleName
            };
            var result = await _roleManager.CreateAsync(newRole);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(RoleRequest request)
        {
            var roleFromDb = await _roleManager.FindByNameAsync(request.RoleName);
            if (roleFromDb == null)
                return false;
            var result = await _roleManager.DeleteAsync(roleFromDb);
            return result.Succeeded;
        }

        public async Task<bool> AssignRoleToUser(UserRoleRequest request)
        {
            var userFromDb = await _userManager.FindByNameAsync(request.UserName);
            if (userFromDb == null)
                return false;
            var roleFromDb = await _roleManager.FindByNameAsync(request.RoleName);
            if (roleFromDb == null)
                return false;

            var result = await _userManager.AddToRoleAsync(userFromDb, roleFromDb.Name);
            return result.Succeeded;
        }

        public async Task<bool> RevokeRoleFromUser(UserRoleRequest request)
        {
            var userFromDb = await _userManager.FindByNameAsync(request.UserName);
            if (userFromDb == null)
                return false;

            var roleFromDb = await _roleManager.FindByNameAsync(request.RoleName);
            if (roleFromDb == null)
                return false;

            var isInRole = await _userManager.IsInRoleAsync(userFromDb, roleFromDb.Name);
            if (!isInRole)
                return false;

            var result = await _userManager.RemoveFromRoleAsync(userFromDb, request.RoleName);
            return result.Succeeded;
        }
    }
}
