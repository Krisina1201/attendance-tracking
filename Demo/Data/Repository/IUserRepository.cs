using Demo.domain.Models;
using Demo.Domain.ModesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserLocalEnity> GetAllUsers { get; }
        bool RemoveUserById(Guid userGuid);
        UserLocalEnity? UpdateUser(UserLocalEnity user);

        IEnumerable<UserDAO> GetAllUsersDao { get; }
        bool RemoveUserByIdDao(int userId);
        UserDAO? UpdateUserDao(UserDAO user);


    }
}
