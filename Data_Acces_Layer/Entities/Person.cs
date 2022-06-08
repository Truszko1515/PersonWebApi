using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Entities
{
    [Table("Person")]
    public partial class Person
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        [StringLength(100)]
        [RegularExpression(@"A[^\d_]+\z", ErrorMessage = "Invalid Data Type")]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Column("adress")]
        [StringLength(1000)]
        public string Adress { get; set; }
        [Column("phone_number")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }
        [Column("date_of_birth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
    }
}
