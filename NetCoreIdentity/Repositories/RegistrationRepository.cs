using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCoreIdentity.Data;
using NetCoreIdentity.Models;
using NetCoreIdentity.Requests;
using System.Threading.Tasks;

namespace NetCoreIdentity.Repositories
{
    public interface IRegistrationRepository
    {
        Task<ApplicationUser> GetUser(int id);
        Task<bool> RegisterUser(ApplicationUserRequest request);
        Task<bool> EditUser(EditUserRequest request, int id);
        Task<bool> DeleteUser(int id);
    }
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistrationRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userFromDb = await _context.ApplicationUsers.SingleOrDefaultAsync(x => x.Id == id);

            if (userFromDb == null) return false;

            var isDeleted = await _userManager.DeleteAsync(userFromDb);
            return isDeleted.Succeeded;
        }

        public async Task<bool> EditUser(EditUserRequest request, int id)
        {
            var userFromDb = await _context.ApplicationUsers.SingleOrDefaultAsync(x => x.Id == id);
            if (userFromDb == null) return false;

            // maping
            userFromDb.FirstName = request.FirstName;
            userFromDb.LastName = request.LastName;
            userFromDb.Age = request.Age;
            userFromDb.Sex = request.Sex;

            var isEditted = await _userManager.UpdateAsync(userFromDb);
            return isEditted.Succeeded;
        }

        public async Task<ApplicationUser> GetUser(int id)
        {
            return await _context.ApplicationUsers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> RegisterUser(ApplicationUserRequest request)
        {
            var user = request.GetModel();
            var response = await _userManager.CreateAsync(user, request.Password);
            return response.Succeeded;
        }
    }
}
