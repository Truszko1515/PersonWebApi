using Data_Acces_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        //Person GetPersonById(int id);
        Task<Person> GetPersonByIdAsync(int id);
        //void PostPerson(Person person);
        Task<int> PostPersonAsync(Person person);
        Task DeletePersonAsync(int id);
        Task UpdatePersonAsync(int id, Person person);
    }
}
