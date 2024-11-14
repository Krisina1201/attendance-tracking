using Demo.Domain.RemoteDatabase;
using Demo.Domain.UseCase;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class GroupConsoleUI
    {
        GroupUseCase _groupUseCase;
        public GroupConsoleUI(GroupUseCase groupUseCase)
        {
            _groupUseCase = groupUseCase;
        }

        public void RemoveGroupById(int Id)
        {
            _groupUseCase.RemoveGroupById(Id);
        }

        public void addGroup(string GtrtoupName) {
            _groupUseCase.AddGroup(GtrtoupName);
        }


        public void DisplayAllGroup()
        {
            StringBuilder groupOutput = new StringBuilder();
            foreach (var group in _groupUseCase.GetAllGroups())
            {
                groupOutput.AppendLine($"{group.Id}\t{group.Name}");
            }
            Console.WriteLine(groupOutput);
        }

        public void UpdateGroup(int Id, string nameGroup)
        {
            try
            {
                var updatedGroup = _groupUseCase.UpdateGroup(Id, nameGroup);
                Console.WriteLine($"Группа обновленна успешно обновлена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public void GetGroupById(int Id, string nameGroup)
        {
            _groupUseCase.GetGroupById(Id, nameGroup);
            Console.WriteLine($"Группа удалена по введенному айди");
        }
    }
}
