using Business_Logic_Layer.Models;
using Data_Acces_Layer.Entities;
using Data_Acces_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class PersonBLL : IPersonBLL
    {
        private readonly IPersonRepository _personRepository;

        public PersonBLL(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<PersonModel>> GetAllPersonsAsync()
        {
            var results = await _personRepository.GetAllPersonsAsync();
            return results.Select(p => new PersonModel(p));
        }

        public async Task<PersonModel> GetPersonByIdAsync(int id)
        {
            var result = await _personRepository.GetPersonByIdAsync(id);
            if (result == null)
                throw new Exception("Person with given id was not found");
            PersonModel personModel = new PersonModel(result);
            return personModel;
        }

        public async Task<int> PostPersonAsync(PersonModel personModel)
        {
            Person person = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Adress = personModel.Adress,
                PhoneNumber = personModel.PhoneNumber,
                DateOfBirth = personModel.DateOfBirth
            };

            return await _personRepository.PostPersonAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            if (_personRepository.GetPersonByIdAsync(id) == null)
                throw new Exception("Person with given id doesnt exist");
            await _personRepository.DeletePersonAsync(id);
        }
        public async Task UpdatePersonAsync(int id, PersonModel personModel)
        {
            Person person = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Adress = personModel.Adress,
                PhoneNumber = personModel.PhoneNumber,
                DateOfBirth = personModel.DateOfBirth
            };
            await _personRepository.UpdatePersonAsync(id, person);
        }
    }
}
