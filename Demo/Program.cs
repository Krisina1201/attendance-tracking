
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.Data.Repository;
using Demo.Domain.UseCase;
using Demo.UI;
using Microsoft.Extensions.DependencyInjection;

// Создаем экземпляр репозиториев

IServiceCollection services = new ServiceCollection();

services
    .AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IGroupRepository, SQLGroupRepositoryImpl>()
    .AddSingleton<IUserRepository, SQLUserRepositoryImpl>()
    .AddSingleton<IPresenceRepository, SQLPresenceRepositoryImpl>()
    .AddSingleton<UserUseCase>()
    .AddSingleton<GroupUseCase>()
    .AddSingleton<UseCaseGeneratePresence>()
    .AddSingleton<GroupConsoleUI>()
    .AddSingleton<PresenceConsoleUI>()
    .AddSingleton<MainMenuUI>();




var serviceProvider = services.BuildServiceProvider();
// Создаем пользовательский интерфейс
MainMenuUI mainMenuUI = serviceProvider.GetService<MainMenuUI>();

// Выводим главное меню
mainMenuUI!.DisplayMenu();