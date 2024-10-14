using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.LocalData
{
    public static class LocalStaticData
    {
        public static List<GroupLocalEntity> groups => new List<GroupLocalEntity>
        
        {
            new GroupLocalEntity{ Id = 1, Name = "ИП1-21" },
            new GroupLocalEntity{ Id = 2, Name = "ИП1-22" },
            new GroupLocalEntity{ Id = 3, Name = "ИП1-23" },
        };

        public static List<UserLocalEnity> users => new List<UserLocalEnity>
        {
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio", GroupID = 1 },
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio1", GroupID = 2 },
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio2", GroupID = 3 },
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio3", GroupID = 1 },
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio4", GroupID = 2 },
            new UserLocalEnity{Guid=Guid.NewGuid(), FIO = "RandomFio5", GroupID = 3 },
        };
    }
}
