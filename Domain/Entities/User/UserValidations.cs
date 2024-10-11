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
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(request.Email))
            {
                errors.Add("Please, inform your e-mail.");
            }

            if (errors.Count == 0 && _iUserRepository.Exist(new Queries.ExistUserQuery() { Email = request.Email }))
                errors.Add("User already exists.");

            return errors;
        }

        public List<string> EditUserValidation(EditUserCommand request)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(request.Email))
            {
                errors.Add("Please, inform your e-mail.");
            }

            // Verifica se o email é diferente do existente
            if (errors.Count == 0 && _iUserRepository.Exist(new Queries.ExistUserQuery() { Email = request.Email, Id = request.Id }))
                errors.Add("User already exists with a different email.");

            return errors;
        }
    }
}
