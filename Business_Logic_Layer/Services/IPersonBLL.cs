using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface IPersonBLL
    {
        Task<IEnumerable<PersonModel>> GetAllPersonsAsync();
        //PersonModel GetPersonById(int id);
        Task<PersonModel> GetPersonByIdAsync(int id);
        // void PostPerson(PersonModel personModel);
        //void PostPerson(PersonModel personModel);
        Task<int> PostPersonAsync(PersonModel personModel);
        Task DeletePersonAsync(int id);
        Task UpdatePersonAsync(int id, PersonModel personModel);
    }
}
