// capture person data
using Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public City City { get; set; } = default!;
}