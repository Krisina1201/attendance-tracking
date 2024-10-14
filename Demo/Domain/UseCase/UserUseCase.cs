using Demo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.UseCase
{
    public class UserUseCase
    {
        private UserRepositoryImpl _repositoryImpl;

        public UserUseCase(UserRepositoryImpl repositoryImpl)
        {
            _repositoryImpl = repositoryImpl;
        }

    }
}
