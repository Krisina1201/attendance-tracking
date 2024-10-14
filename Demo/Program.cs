

using Demo.Data.Repository;
using Demo.domain.Models;
using Demo.Domain.UseCase;

GroupRepositoryImpl groupRepositoryImpl = new GroupRepositoryImpl();
UserRepositoryImpl userRepositoryImpl = new UserRepositoryImpl();
UserUseCase userUseCase = new UserUseCase(userRepositoryImpl, groupRepositoryImpl);

List<User> users = userUseCase.GetAllUsers;

foreach (var user in users) {
    Console.WriteLine($"{user.FIO} группа {user.Group.Name}");
}

userUseCase.


Console.ReadKey();