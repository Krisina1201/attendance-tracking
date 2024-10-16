﻿using Demo.Domain.UseCase;
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
            DisplayMenu();
            
        }

        private void DisplayMenu() {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;

                    default: DisplayMenu();
                        break;
                }

            }
        }
        
    }
}
