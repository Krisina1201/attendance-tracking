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
       public List<GroupLocalEntity> GetAllGroups() => LocalStaticData.groups;
    }
}
