// class to implement IPeopleRepository
using Microsoft.EntityFrameworkCore;
using Models;

public class PeopleRepository : IPeopleRepository
{
    private readonly PeopleContext _context;
    public PeopleRepository(PeopleContext context)
    {
        _context = context;
        
        // add some data to the in-memory database
        _context.People.Add(new Person { Name = "John", Age = 25, City = new City { Name = "New York" } });
        _context.People.Add(new Person { Name = "Jane", Age = 22, City = new City { Name = "Chicago" } });
        _context.People.Add(new Person { Name = "Tom", Age = 30, City = new City { Name = "Los Angeles" } });
        _context.People.Add(new Person { Name = "Sue", Age = 21, City = new City { Name = "Houston" } });
        _context.People.Add(new Person { Name = "Bill", Age = 19, City = new City { Name = "Phoenix" } });
        _context.People.Add(new Person { Name = "Mary", Age = 29, City = new City { Name = "Philadelphia" } });
        _context.People.Add(new Person { Name = "Bob", Age = 27, City = new City { Name = "San Antonio" } });
        _context.People.Add(new Person { Name = "Alice", Age = 23, City = new City { Name = "San Diego" } });   
        
        _context.SaveChanges();
    }
    public async Task<List<Person>> GetPeopleAsync()
    {
        return await _context.People.ToListAsync();
    }
    public async Task<Person> GetPersonAsync(int id)
    {
        // List<Person> people = await _context.People.ToListAsync();

        // foreach (Person person in people)
        // {
        //     if (person.Id == id)
        //     {
        //         await Task.Delay(5000);
        //         return person;
        //     }
        // }
        // return new Person();

        var person = await _context.People
            .AsNoTracking() // Improves performance by not tracking the entity
            .FirstOrDefaultAsync(p => p.Id == id);

        return person ?? new Person(); // Return a new Person if not found        
    }
    public async Task<Person> AddPersonAsync(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> UpdatePersonAsync(Person person)
    {
        Person item = await _context.People.FindAsync(person.Id);
        if (item != null)
        {
            _context.Entry(item).CurrentValues.SetValues(person);
            await _context.SaveChangesAsync();
            return item;
        }
        return new Person();
    }

    public Task<Person> DeletePersonAsync(int id)
    {
        Person item = _context.People.Find(id);
        if (item != null)
        {
            _context.People.Remove(item);
            _context.SaveChanges();
        }
        return Task.FromResult(item);
    }
}