using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Actions
            Action PrintDateTime = () =>
            {
                Console.Clear();
                if (DateTime.Now.Minute < 10)
                    Console.WriteLine($"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}  {DateTime.Now.Hour}:0{DateTime.Now.Minute}\n");
                else
                    Console.WriteLine($"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}  {DateTime.Now.Hour}:{DateTime.Now.Minute}\n");
            };

            Action<string> WarningNumbersOnly = delegate (string title)
            {
                PrintDateTime();    
                Console.WriteLine($"Only numbers are allowed as an option in {title}.");
            };

            #endregion

            int user;


            PrintDateTime();
            using (CompanyContext CreateDB = new CompanyContext("CompanyConStr"))
            {
                Console.WriteLine("Loading Database . . .\n");
                CreateDB.Database.CreateIfNotExists();

                Console.WriteLine("Done");
                Thread.Sleep(1000);
            }
            #region LoginPage
            Login:
            PrintDateTime();
            Console.Write("Enter Username(ID): ");
            user = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            using (CompanyContext DbCredValidation = new CompanyContext("CompanyConStr"))
            {
                if(DbCredValidation.Employer.Any(t => t.ID == user && t.Password == pass))
                {
                    //goto EmployerMainMenu;
                }
                else if (DbCredValidation.Employees.Any(t => t.ID == user && t.Password == pass))
                {
                    var employee = DbCredValidation.Employees.FirstOrDefault(t => t.ID == user);
                    Console.WriteLine($"Welcome {employee.Name}!");
                    Thread.Sleep(1000);
                    goto EmployeePassChange;  
                }
                else
                {
                    PrintDateTime();
                    Console.WriteLine("Incorrect username or password.\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Please try again.");
                    goto Login;
                }
            }
        #endregion

        EmployeePassChange:
            PrintDateTime();
        #region EmployeePassChange
            Console.WriteLine("Please change your password.\n");
            Thread.Sleep(1000);
            PrintDateTime();
            Console.Write("New password: ");
            string newPass = Console.ReadLine();
            Console.Write("Confirm: ");
            string passConfirm = Console.ReadLine();
            if (newPass == passConfirm)
            {
                
                PrintDateTime();
                Employee.NewPassword(user, newPass);
                Console.WriteLine("Password changed successfully!");
                Thread.Sleep(1000);
                //goto EmployeeMainMenu;

            }
            else
            {
                PrintDateTime();
                Console.WriteLine("Passwords don't match.");
                Thread.Sleep(1000);
                Console.WriteLine("Please try again.");
                goto EmployeePassChange;
            }

            #endregion

        #region EmployeeMainMenu
        EmployeeMainMenu:
            PrintDateTime();
            Console.WriteLine("1. View statistics\n2. Join a group\n3. Change password");
        #endregion

        Group:;



        }
    }
}
