
using Demo.Data.Repository;
using Demo.Domain.UseCase;
using Demo.UI;

GroupRepositoryImpl groupRepositoryImpl = new GroupRepositoryImpl();
UserRepositoryImpl userRepositoryImpl = new UserRepositoryImpl();
UserUseCase UserUseCase = new UserUseCase(userRepositoryImpl, groupRepositoryImpl);

MainMenuUI mainMenuUI = new MainMenuUI(UserUseCase);