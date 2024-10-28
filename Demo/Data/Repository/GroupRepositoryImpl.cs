using Demo.Data.LocalData;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public class GroupRepositoryImpl
    {
        public GroupRepositoryImpl()
        {
            GetAllGroups = LocalStaticData.groups;
        }
        public List<GroupLocalEntity> GetAllGroups
        { get; set; }


        public bool RemoveGroupById(int id)
        {
            GroupLocalEntity? groupLocal = GetAllGroups
                .Where(x => x.Id == id).FirstOrDefault();
            if (groupLocal == null) return false;

            return GetAllGroups.Remove(groupLocal);
        }

        public GroupLocalEntity? GetGroupByGuid(int id)
        {
            GroupLocalEntity? groupLocal = GetAllGroups
                    .Where(x => x.Id == id).FirstOrDefault();
            if (groupLocal == null) return null;

            return groupLocal;
        }

        public GroupLocalEntity? UpdateGroup(GroupLocalEntity groupUpdateLocalEnity)
        {
            GroupLocalEntity? groupLocal = GetAllGroups
                    .Where(x => x.Id == groupUpdateLocalEnity.Id).FirstOrDefault();
            if (groupLocal == null) return null;
            groupLocal.Name = groupUpdateLocalEnity.Name;
            return groupLocal;

        }
    }


}
