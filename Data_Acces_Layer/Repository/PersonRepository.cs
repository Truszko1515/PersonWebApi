using Data_Acces_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;

        public PersonRepository(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _dbContext.Person.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var p = await _dbContext.Person.FirstOrDefaultAsync(p => p.Id == id);

            return p;
        }
        public async Task<int> PostPersonAsync(Person person)
        {
            await _dbContext.Person.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person.Id;
        }
        public async Task DeletePersonAsync(int id)
        {
            var p = await _dbContext.Person.FirstOrDefaultAsync(p => p.Id == id);

            if (p == null)
                throw new Exception("Not Found");

            _dbContext.Person.Remove(p);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdatePersonAsync(int id, Person person)
        {
            var p = await _dbContext.Person.FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
                throw new Exception("Not Found");

            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.PhoneNumber = person.PhoneNumber;
            p.Adress = person.Adress;
            p.DateOfBirth = person.DateOfBirth;

            await _dbContext.SaveChangesAsync();
        }
    }
}
