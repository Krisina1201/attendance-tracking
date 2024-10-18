using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class GroupConsoleUI
    {
        GroupUseCase _groupUseCase;
        public UserConsoleUI(GroupUseCase groupUseCase)
        {
            _groupUseCase = groupUseCase;
        }

        public UpdateGroups()
        {
            string output = _groupUseCase.UpdateGroup("бла бла бла") ? "Группа обновлена" : "Группа не обновлена";
            Console.WriteLine(output);
        }

        public void RemoveGroupByGuid(int id)
        {

            string output = _groupUseCase.RemoveGroupByGuid(id) ? "Группа удалена" : "Группа не удалена";
            Console.WriteLine(output);
        }

        public void GetGroupById(int id)
        {
            Console.WriteLine(GetGroupById1(id));
        }

        public void DisplayAllGroup()
        {
            StringBuilder userOutput = new StringBuilder();
            foreach (var user in _groupUseCase.GetAllGroup())
            {
                userOutput.AppendLine($"{group.Id}\t{group.Name}");
            }
            Console.WriteLine(userOutput);
        }
    }
}
