using Demo.Domain.RemoteDatabase;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class UserConsoleUI
    {
        UserUseCase _userUseCase;
        public UserConsoleUI(UserUseCase userUseCase) {
            _userUseCase = userUseCase;
        }

        public void RemoveUserByGuid(Guid guidUser) {

            string output = _userUseCase.RemoveUserByGuid(guidUser) ? "Пользователь удален" : "Пользователь не удален";
            Console.WriteLine(output);
        }

        public void DisplayAllUsers()
        {
            StringBuilder userOutput = new StringBuilder();
            foreach (var user in _userUseCase.GetAllUsers())
            {
                userOutput.AppendLine($"{user.Guid}\t{user.FIO}\t{user.Group.Name}");
            }
            Console.WriteLine(userOutput);
        }

        public void UpdateUser(User user)
        {
            try
            {
                User updatedUser = _userUseCase.UpdateUser(user);
                Console.WriteLine($"Пользователь обновлен: {updatedUser.FIO}, Группа: {updatedUser.Group.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public void GetUserByGuid(Guid userGuid)
        {
            var output = _userUseCase.GetUserByGuid(userGuid);
            Console.WriteLine($"Пользователь по введенному гюиду: {output}");
        }
    }
}
