using AutomationPracticeWebApp.Common.Enums;
using System;

namespace AutomationPracticeWebApp.Common.Models
{
    public class UserAccount
    {
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DoB { get; set; }
        public UserAddress Address { get; set; }
    }
}
