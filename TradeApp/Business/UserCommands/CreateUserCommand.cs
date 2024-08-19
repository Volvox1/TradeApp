using AutoMapper;
using Entities;
using Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserCommands
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IDBContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommand(IDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public  void Handle()
        {
            User user = new User();
            user = _context.Users.SingleOrDefault(x => x.Email == Model.Email)!;
            if (user != null)
            {
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            }
            user = new User();
            user.Email=Model.Email;
            user.Password=Model.Password;
            user.Name=Model.Name;
            user.Surname=Model.Surname;

            _context.Users.Add(user);
            _context.SaveChanges();
        }


    }
    public class CreateUserModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
