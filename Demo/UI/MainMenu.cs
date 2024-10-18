using Demo.domain.Models;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class MainMenuUI
    {

        UserConsoleUI _userConsoleUI;

        public MainMenuUI(UserUseCase userUseCase) { 
        _userConsoleUI = new UserConsoleUI(userUseCase);
            DisplayMenu();
            
        }


        private void DisplayMenu() {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;
                    case "3": _userConsoleUI.UpdateUser(Split(Console.ReadLine())); break;
                    case "4": _userConsoleUI.GetUserByGuid("614c0a23-5bd5-43ae-b48e-d5750afbc282"); break;
                    default: DisplayMenu();
                        break;
                }

            }
        }
        
    }
}
