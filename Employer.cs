using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company
{
    class Employer : User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int ID { get; set; }
        public Employer(string Name, string LastName, string NationalCode, string PhoneNumber, string Email, int Salary):base(Name, LastName, NationalCode, PhoneNumber, Email, Salary) { }
    }
}
