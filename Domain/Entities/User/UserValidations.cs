using Domain.Commons;
using Domain.Entities.User.Commands;
using Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserValidations : Validation
    {
        private readonly IUserRepository _iUserRepository;

        public UserValidations(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public List<string> AddUserValidation(AddUserCommand request)
        {
            if (Errors.Count == 0 && _iUserRepository.Exist(new Queries.ExistUserQuery() { Email = request.Email, Id = request.Id })) 
            {
                Errors.Add("User already exists.");
            }

            if (string.IsNullOrEmpty(request.Email))
                Errors.Add("Please, inform your e-mail");

            return Errors;
        }
    }
}
