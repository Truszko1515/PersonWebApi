using Data_Acces_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class PersonModel
    {
        public PersonModel(Person p)
        {
            Id = p.Id;
            FirstName = p.FirstName;
            LastName = p.LastName;
            Adress = p.Adress;
            PhoneNumber = p.PhoneNumber;
            DateOfBirth = p.DateOfBirth;
        }
        public PersonModel()
        {

        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
