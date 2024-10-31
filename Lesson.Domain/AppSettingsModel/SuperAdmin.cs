using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.AppSettingsModel
{
    public class SuperAdmin
    {
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}

