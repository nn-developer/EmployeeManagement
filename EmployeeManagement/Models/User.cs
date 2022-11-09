using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("user")]
    public class User
    {
        public User() { }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        //public long Id { get; set; }

        [Required]
        [Column("uid")]
        public Guid Uid { get; set; }

        [Required]
        [Column("user_id")]
        [MaxLength(50)]
        public string UserId { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Column("remark")]
        [MaxLength(1000)]
        public string Remark { get; set; }

        [Required]
        [Column("update_at")]
        public DateTime UpdateAt { get; set; }
    }
}
