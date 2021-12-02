using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumer { get; set; }
        public bool? PhoneNumerConfirmed { get; set; }
        public bool? TwoFactoryEnabled { get; set; }
        public DateTime? LockoutDate { get; set; }
        public bool? Lockout { get; set; }
        public string UserName { get; set; }
    }
}
