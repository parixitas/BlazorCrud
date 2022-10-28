using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Data
{
    public class UserService
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public UserService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Employees
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDBContext.User.ToListAsync();
        }
        #endregion

        #region Insert Employee
        public async Task<bool> InsertUserAsync(User user)
        {
            await _appDBContext.User.AddAsync(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Employee by Id
        public async Task<User> GetUserAsync(int Id)
        {
            User employee = await _appDBContext.User.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return employee;
        }
        #endregion

        #region Update Employee
        public async Task<bool> UpdateUserAsync(User user)
        {
             _appDBContext.User.Update(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteEmployee
        public async Task<bool> DeleteUserAsync(User user)
        {
            _appDBContext.Remove(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
