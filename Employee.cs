using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company
{
    class Employee : User
    { 
        [Required]
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public Role RoleID { get; set; }
        public DateTime RegisterDate { get; set; }
        public Employee() { }
        
        public Employee(string Department, string Name, string LastName, string NationalCode, string PhoneNumber, string Email, int Salary,Role RoleID, DateTime RegisterDate) : base(Name, LastName, NationalCode, PhoneNumber, Email, Salary)
        {
            this.Department = Department;
            this.IsActive = true;
            this.RoleID = RoleID;
            RegisterDate = DateTime.Now;

        }

        static public void NewPassword(int User, string newPass)
        {
            using(CompanyContext DbChangePass = new CompanyContext("CompanyConStr"))
            {
                var employee = DbChangePass.Employees.Find(User);
                employee.Password = newPass;
                DbChangePass.SaveChanges();
            }
            
        }
       
        


    }
}
