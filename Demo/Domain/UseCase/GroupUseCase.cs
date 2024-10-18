using Demo.Data.Repository;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.UseCase
{
    public class GroupUseCase
    {
        private UserRepositoryImpl _repositoryUserImpl;
        private GroupRepositoryImpl _repositoryGroupImpl;

        public GroupUseCase(UserRepositoryImpl repositoryImpl, GroupRepositoryImpl repositoryGroupImpl)
        {
            _repositoryUserImpl = repositoryImpl;
            _repositoryGroupImpl = repositoryGroupImpl;
        }

        public List<Group> GetAllGroups() => _repositoryGroupImpl.GetAllGroups()
              .Select(it => new Group { Id = it.Id, Name = it.Name }).ToList();

        //public List<User> GetAllUsers() => _repositoryUserImpl.GetAllUsers
        //      .Join(_repositoryGroupImpl.GetAllGroups(),
        //      user => user.GroupID,
        //      group => group.Id,
        //      (user, group) =>
        //      new User                                                                                 
        //      {
        //          FIO = user.FIO,
        //          Guid = user.Guid,
        //          Group = new Group { Id = group.Id, Name = group.Name }
        //      }
        //    ).ToList();

        public bool RemoveGroupId(int id)
        {
            return _repositoryGroupImpl.RemoveGroupById(id);
        }

        public List<Group> GetGroupById1(int id)
        {
            return _repositoryGroupImpl.GetGroupByid(id);
        }

        public Group UpdateGroup(Group group)
        {
            GroupLocalEnity groupLocalEnity = new GroupLocalEnity { Id = group.Id, Name = group.name };
            GroupLocalEnity? result = _repositoryGroupImpl.UpdateGroup(groupLocalEnity);
            if (result == null) throw new Exception("");
            Group? group = GetAllGroups().FirstOrDefault(it => it.Id == result!.GroupID);
            if (group == null) throw new Exception("");
            return new Group { Id = group.Id, Name = group.name };
        }
    }
}
