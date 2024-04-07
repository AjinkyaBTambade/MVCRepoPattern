using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Department Id")]
        public int DeptId { get; set; }

        [DisplayName("Manager Id")]
        public int ManagerId { get; set; }
    }
}

