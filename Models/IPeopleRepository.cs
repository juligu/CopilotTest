public interface IPeopleRepository
{
    Task<List<Person>> GetPeopleAsync();
    Task<Person> GetPersonAsync(int id);
    Task<Person> AddPersonAsync(Person person);
    Task<Person> UpdatePersonAsync(Person person);
    Task<Person> DeletePersonAsync(int id);
}