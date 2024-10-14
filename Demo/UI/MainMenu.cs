using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
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
        _userConsoleUI.DisplayAllUsers();
        }
        
    }
}
