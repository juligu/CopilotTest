// class to store state information
namespace Models;
public class State
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<City> Cities { get; set; }
}