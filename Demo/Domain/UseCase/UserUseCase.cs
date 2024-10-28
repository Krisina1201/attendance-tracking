using Demo.Data.Repository;
using Demo.domain.Models;
using Demo.Domain.RemoteDatabase;

namespace Demo.Domain.UseCase
{
    public class UserUseCase
    {
        private readonly IUserRepository _repositoryUserImpl;
        private readonly IGroupRepository _repositoryGroupImpl;

        public UserUseCase(IUserRepository repositoryImpl, IGroupRepository repositoryGroupImpl)
        {
            _repositoryUserImpl = repositoryImpl;
            _repositoryGroupImpl = repositoryGroupImpl;
        }

        private void ValidateUserFIO(string fio)
        {
            if (string.IsNullOrWhiteSpace(fio))
            {
                throw new ArgumentException("ФИО не может быть пустым.");
            }
        }


        private UserLocalEnity ValidateUserExistence(Guid userGuid)
        {
            var user = _repositoryUserImpl.GetAllUsers
                .FirstOrDefault(u => u.Guid == userGuid);

            if (user == null)
            {
                throw new Exception("Пользователь не найден.");
            }

            return user;
        }

        private GroupLocalEntity ValidateGroupExistence(int groupId)
        {
            var group = _repositoryGroupImpl.GetAllGroup()
                .FirstOrDefault(g => g.Id == groupId);

            if (group == null)
            {
                throw new Exception("Группа не найдена.");
            }

            return group;
        }

        public List<User> GetAllUsers() => _repositoryUserImpl.GetAllUsers
            .Join(_repositoryGroupImpl.GetAllGroup(),
            user => user.GroupID,
            group => group.Id,
            (user, group) =>
            new User
            {
                FIO = user.FIO,
                Guid = user.Guid,
                Group = new Group { Id = group.Id, Name = group.Name }
            }).ToList();

        public bool RemoveUserByGuid(Guid userGuid)
        {
            return _repositoryUserImpl.RemoveUserById(userGuid);
        }

        public User UpdateUser(User user)
        {
            ValidateUserFIO(user.FIO);
            ValidateGroupExistence(user.Group.Id);

            UserLocalEnity userLocalEnity = new UserLocalEnity
            {
                FIO = user.FIO,
                GroupID = user.Group.Id,
                Guid = user.Guid
            };

            UserLocalEnity? result = _repositoryUserImpl.UpdateUser(userLocalEnity);

            if (result == null)
            {
                throw new Exception("Ошибка при обновлении пользователя.");
            }

            var groupEntity = ValidateGroupExistence(result.GroupID);

            return new User
            {
                FIO = result.FIO,
                Guid = result.Guid,
                Group = new Group
                {
                    Id = groupEntity.Id,
                    Name = groupEntity.Name
                }
            };
        }

        public User GetUserByGuid(Guid userGuid)
        {
            var user = ValidateUserExistence(userGuid);
            var group = ValidateGroupExistence(user.GroupID);

            return new User
            {
                FIO = user.FIO,
                Guid = user.Guid,
                Group = new Group { Id = group.Id, Name = group.Name }
            };
        }
    }
}
