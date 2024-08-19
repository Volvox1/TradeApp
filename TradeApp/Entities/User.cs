using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExprireDate { get; set; }

    }
}
