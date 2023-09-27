using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company
{
    class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; } = AutoID;
        static int AutoID { get; set; } = 100;
        [Required]
        [Column(TypeName = "varchar")]
        public Employee GroupLeaderID { get; set; }
        public virtual List<Employee> GroupMembers { get; set;}
        
        public Group(int GroupID, Employee GroupLeaderID)
        {
            using (CompanyContext DbIdCheck = new CompanyContext("CompanyConStr"))
            {
                if (!DbIdCheck.Groups.Any())
                    GroupID = AutoID;
                else
                    GroupID = DbIdCheck.Groups.Max(x => x.GroupID);

                DbIdCheck.SaveChanges();
            }
            this.GroupLeaderID = GroupLeaderID;
            GroupMembers = new List<Employee>();
            GroupID++;
            
        }
    }
}
