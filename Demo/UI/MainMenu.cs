using Demo.domain.Models;
using Demo.Domain.RemoteDatabase;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class MainMenuUI
    {

        GroupConsoleUI _groupConsoleUI;
        UserConsoleUI _userConsoleUI;

        public MainMenuUI(UserUseCase userUseCase, GroupUseCase groupUseCase) { 
        _userConsoleUI = new UserConsoleUI(userUseCase);
        _groupConsoleUI = new GroupConsoleUI(groupUseCase);
         
            
        }


        public void DisplayMenu() {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;
                    case "3": _userConsoleUI.UpdateUser(
                        new User { FIO = Console.ReadLine(), 
                            Guid = Guid.Parse(Console.ReadLine()), 
                            Group = new Group { Id = Convert.ToInt32(Console.ReadLine()), Name = Console.ReadLine()} }
                        ); break;
                    case "4": _userConsoleUI.GetUserByGuid(Guid.Parse(Console.ReadLine())); break;
                    case "5": _groupConsoleUI.DisplayAllGroup(); break;
                    case "6":_groupConsoleUI.addGroup(Console.ReadLine()); break;
                    case "7":
                        _groupConsoleUI.UpdateGroup(
                        new Group
                        {
                            Id = int.Parse(Console.ReadLine()),
                            Name = Console.ReadLine()
                        }
                        ); break;
                    case "8": _groupConsoleUI.GetGroupById(int.Parse(Console.ReadLine())); break;
                    default: DisplayMenu();
                        break;
                }

            }
        }
        
    }
}
