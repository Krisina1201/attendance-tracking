using Demo.Data.LocalData;
using Demo.Data.Repository;
using Demo.domain.Models;
using Demo.Domain.RemoteDatabase;
using System.Text.RegularExpressions;
using Group = Demo.Domain.RemoteDatabase.Group;

namespace Demo.Domain.UseCase
{
    public class GroupUseCase
    {
        private readonly IGroupRepository _repositoryGroupImpl;

        public GroupUseCase(IGroupRepository repositoryGroupImpl)
        {
            _repositoryGroupImpl = repositoryGroupImpl;
        }

        private void ValidateGroupName(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("Имя группы не может быть пустым.");
            }
        }

        private void ValidateGroupId(int GroupId)
        {
            if (GroupId < 1)
            {
                throw new ArgumentException("Введите корректный ID группы.");
            }
        }

        private GroupLocalEntity ValidateGroupExistence(int groupId)
        {
            var existingGroup = _repositoryGroupImpl.GetAllGroup()
                .FirstOrDefault(g => g.Id == groupId);

            if (existingGroup == null)
            {
                throw new ArgumentException("Группа не найдена.");
            }

            return existingGroup;
        }


        public List<Group> GetAllGroups()
        {
            return [.. _repositoryGroupImpl.GetAllGroup()
                .Select(it => new Group { Id = it.Id, Name = it.Name })];
        }



        public void GetGroupById(int IdGroup, string nameGroup)
        {
            List<Group> GetAllGroups()
            {
            return [.. _repositoryGroupImpl
                    .GetAllGroup()
                    .Select(
                        it => new Group
                        { Id = it.Id, Name = it.Name }
                        )
                ];
            }
            foreach (var group in GetAllGroups())
            {
                if (IdGroup == group.Id)
                {
                    string n = group.Id + group.Name;
                }
            }
        }


        public void AddGroup(string groupName)
        {
          

            GroupLocalEntity newGroup = new GroupLocalEntity
            {
                Name = groupName
            };

            _repositoryGroupImpl.AddGroup(newGroup);
        }

        public void RemoveGroupById(int groupId)
        {
            ValidateGroupId(groupId);
            var existingGroup = ValidateGroupExistence(groupId);
            List<Group> _groups = GetAllGroups();
            var groupToRemove = _groups.FirstOrDefault(g => g.Id == existingGroup.Id);
            if (groupToRemove != null)
            {
                _groups.Remove(groupToRemove);
                _repositoryGroupImpl.RemoveGroupById(existingGroup.Id);
            }
            else
            {
                throw new ArgumentException("Группа не найдена.");
            }
        }


        public bool UpdateGroup(int groupId, string newGroupName)
        {
            ValidateGroupName(newGroupName);
            var existingGroup = ValidateGroupExistence(groupId);

            existingGroup.Name = newGroupName;
            return _repositoryGroupImpl.UpdateGroupById(existingGroup.Id, existingGroup);
        }
    }
}