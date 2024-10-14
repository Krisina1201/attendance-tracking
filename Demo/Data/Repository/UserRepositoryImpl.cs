using Demo.Data.LocalData;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public class UserRepositoryImpl
    {
        public List<UserLocalEnity> GetAllUsers() => LocalStaticData.users;

        public bool RemoveUserByGuid(Guid userGuid)
        {
            UserLocalEnity? userLocal = LocalStaticData
                .users
                .Where(x => x.Guid == userGuid).FirstOrDefault();
            if (userLocal == null) return false;

            return LocalStaticData.users.Remove(userLocal);
        }

        public UserLocalEnity? GetUserByGuid(Guid userGuid) {
            UserLocalEnity? userLocal = LocalStaticData
                    .users
                    .Where(x => x.Guid == userGuid).FirstOrDefault();
            if (userLocal == null) return null;

            return userLocal;
        }

        public UserLocalEnity? UpdateUser(UserLocalEnity userUpdateLocalEnity) {
            UserLocalEnity? userLocal = LocalStaticData
                    .users
                    .Where(x => x.Guid == userUpdateLocalEnity.Guid).FirstOrDefault();
            if (userLocal == null) return null;
            userLocal.FIO = userUpdateLocalEnity.FIO;
            userLocal.GroupID = userUpdateLocalEnity.GroupID;
            return userLocal;

        }
    }
}
