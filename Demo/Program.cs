
using Demo.Data.Repository;
using Demo.Domain.RemoteDatabase;
using Demo.Domain.UseCase;
using Demo.UI;
using Microsoft.Extensions.DependencyInjection;

GroupRepositoryImpl groupRepositoryImpl = new GroupRepositoryImpl();
UserRepositoryImpl userRepositoryImpl = new UserRepositoryImpl();
//UserUseCase UserUseCase = new UserUseCase(userRepositoryImpl, groupRepositoryImpl);

//MainMenuUI mainMenuUI = new MainMenuUI(UserUseCase);

IServiceCollection services = new ServiceCollection();
services.AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IGroupRepository, SQLGroupRepositoryImpl>()
    .AddSingleton<IUserRepository, SQLUserRepositoryImpl>()
    .AddSingleton<GroupUseCase>()
    .AddSingleton<GroupConsoleUI>()
    .AddSingleton<UserUseCase>()
    .AddSingleton<UserConsoleUI>()
    .AddSingleton<MainMenuUI>()
    ;

var serviceProvider = services.BuildServiceProvider();
var mainMenu = serviceProvider.GetService<MainMenuUI>();

mainMenu.DisplayMenu();