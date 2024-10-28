using Demo.domain.Models;
using Demo.Domain.ModesDAO;
using Demo.Domain.RemoteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public class SQLGroupRepositoryImpl : IGroupRepository
    {
        private readonly RemoteDatabaseContext _remoteDatabaseContext;

        public SQLGroupRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
        {
            _remoteDatabaseContext = remoteDatabaseContext;
        }

        public bool AddGroup(GroupLocalEntity newGroup)
        {
            GroupDAO groupDAO = new GroupDAO { Name = newGroup.Name };
            _remoteDatabaseContext.Groups.Add(groupDAO);
            _remoteDatabaseContext.SaveChanges();
            return true;
        }


        public bool AddGroupDao(GroupDAO newGroup)
        {
            if (_remoteDatabaseContext.Groups.Any(g => g.Id == newGroup.Id))
                return false; // Возвращает false, если группа с таким ID уже существует

            var daoGroup = newGroup;
            _remoteDatabaseContext.Groups.Add(daoGroup);
            return true;
        }

        public List<GroupLocalEntity> GetAllGroup()
        {
            throw new NotImplementedException();
        }

        public List<GroupDAO> GetAllGroupDao() => _remoteDatabaseContext.Groups
            .Select(g => new GroupDAO { Id = g.Id, Name = g.Name })
            .ToList();

        public GroupLocalEntity GetGroupById(int groupID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroupBuId(int groupId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroupById(int groupID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroupByIdDao(int groupID)
        {
            var existingGroup = _remoteDatabaseContext.Groups.FirstOrDefault(g => g.Id == groupID);
            if (existingGroup == null) return false;

            _remoteDatabaseContext.Groups.Remove(existingGroup);
            return true;
        }

        public bool UpdateGroupById(int groupID, GroupLocalEntity updatedGroup)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGroupByIdDao(int groupID, GroupDAO updatedGroup)
        {
            var existingGroup = _remoteDatabaseContext.Groups.FirstOrDefault(g => g.Id == groupID);
            if (existingGroup == null) return false;

            existingGroup.Name = updatedGroup.Name;
            return true;
        }

        public bool UpdateGroupByTd(int groupId, GroupLocalEntity group)
        {
            throw new NotImplementedException();
        }
    }
}
