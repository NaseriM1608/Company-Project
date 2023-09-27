using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company
{
    abstract class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        public string NationalCode { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        public User() { }
        
        public User(string Name, string LastName, string NationalCode, string PhoneNumber, string Email, int Salary)
        {
            this.ID = ID;
            this.Name = Name;
            this.LastName = LastName;
            this.Password = NationalCode;
            this.NationalCode = NationalCode;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Salary = Salary;
        }



    }
}
