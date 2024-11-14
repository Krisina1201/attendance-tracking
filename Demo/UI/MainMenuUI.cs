using Demo.Data.Repository;
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
    public class MainMenuUI()
    {

        private readonly UserConsoleUI _userConsoleUI;
        private readonly GroupConsoleUI _groupConsoleUI;
        private readonly PresenceConsoleUI _presenceConsoleUI;

        public MainMenuUI(
            UserUseCase userUseCase, 
            GroupUseCase groupUseCase, 
            UseCaseGeneratePresence presenceUseCase, 
            IPresenceRepository presenceRepository) : this()
        {
            _userConsoleUI = new UserConsoleUI(userUseCase);
            _groupConsoleUI = new GroupConsoleUI(groupUseCase);
            _presenceConsoleUI = new PresenceConsoleUI(presenceUseCase, presenceRepository); 
        }



        public void DisplayMenu() {
            while (true)
            {
                Console.WriteLine(
                    "Главное меню:\n" +
                    "1 - Показать всех пользователей\n" +
                    "2 - Удалить пользователя по гюиду\n" +
                    "3 - Добавить пользователя\n" +
                    "4 - Показать пользовтеля по гюиду\n" +
                    "5 - Показать все группы\n" +
                    "6 - Удалить группу\n" +
                    "7 - Добавить группу\n" +
                    "8 - Показать группу по айди\n" +
                    "9 - посмотреть присутствующих по айди группы и дате\n" +
                    "10 - Посмотреть отсутствует ли человек\n" +
                    "11 - Показать посещаемость по всей грууппе\n"
                    );
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
                            int.Parse(Console.ReadLine()),
                            Console.ReadLine()
                        ); break;
                    case "8": _groupConsoleUI.GetGroupById(
                        int.Parse(Console.ReadLine()),
                        Console.ReadLine()
                        ); break;
                    case "9": _presenceConsoleUI.DisplayPresence(DateTime.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())); break;
                    case "10": _presenceConsoleUI.UserAsAbsent(
                        DateTime.Parse(Console.ReadLine()),
                        int.Parse(Console.ReadLine()),
                        Guid.Parse(Console.ReadLine()),
                        int.Parse(Console.ReadLine()),
                        int.Parse(Console.ReadLine())
                        );break;
                    case "11": _presenceConsoleUI.DisplayAllPresenceByGroup(int.Parse(Console.ReadLine())); break;
                    default: DisplayMenu();
                        break;
                }

            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
