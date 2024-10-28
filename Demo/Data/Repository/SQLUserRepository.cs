using Demo.domain.Models;
using Demo.Domain.ModesDAO;
using Demo.Domain.RemoteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data.Repository
{
    public class SQLUserRepositoryImpl : IUserRepository
    {
        private RemoteDatabaseContext _remoteDatabaseContext;

        public SQLUserRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
        {
            _remoteDatabaseContext = remoteDatabaseContext;
        }

        public IEnumerable<UserDAO> GetAllUsers => _remoteDatabaseContext.Users;

        public IEnumerable<UserDAO> GetAllUsersDao => throw new NotImplementedException();

        IEnumerable<UserLocalEnity> IUserRepository.GetAllUsers => throw new NotImplementedException();


        public bool RemoveUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserById(Guid userGuid)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserByIdDao(int userId)
        {
            throw new NotImplementedException();
        }


        public UserLocalEnity? UpdateUser(UserLocalEnity user)
        {
            throw new NotImplementedException();
        }

        public UserDAO? UpdateUserDao(UserDAO user)
        {
            throw new NotImplementedException();
        }
    }
}
