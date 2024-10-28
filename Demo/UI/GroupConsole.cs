using Demo.Domain.RemoteDatabase;
using Demo.Domain.UseCase;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        public void UpdateGroup(Group group)
        {
            try
            {
                //Group updatedGroup = _groupUseCase.UpdateGroup(group);
                //Console.WriteLine($"Группа обновленна: {updatedGroup.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public void GetGroupById(int Id)
        {
            //var output = _groupUseCase.GetGroupById(Id);
            //Console.WriteLine($"Группа удалена по введенному айди: {output}");
        }
    }
}
