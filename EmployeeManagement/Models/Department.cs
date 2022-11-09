using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("department")]
    public class Department
    {
        public Department() { }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("uid")]
        public Guid Uid { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("update_at")]
        public DateTime UpdateAt { get; set; }
    }
}
