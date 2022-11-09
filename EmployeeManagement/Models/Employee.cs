using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("employee")]
    public class Employee
    {
        public static readonly DateTime DEFAULT_BIRTHDAY = DateTime.Parse("1983-01-10");

        public Employee() { }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        //public long Id { get; set; }

        [Required]
        [Column("uid")]
        public Guid Uid { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("family_name")]
        [MaxLength(50)]
        public string FamilyName { get; set; }

        [Required]
        [Column("birthday")]
        public DateTime Birthday { get; set; }

        [Required]
        [Column("gender")]
        public int Gender { get; set; }

        [Column("mail_address")]
        [MaxLength(50)]
        public string MailAddress { get; set; }

        [Required]
        [Column("department_uid")]
        public Guid DepartmentUid { get; set; }

        [Column("remark")]
        [MaxLength(1000)]
        public string Remark { get; set; }

        [Required]
        [Column("update_at")]
        public DateTime UpdateAt { get; set; }
    }
}
