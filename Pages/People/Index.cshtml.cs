
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

public class PeopleModel : PageModel
{
    private readonly IPeopleRepository _context;

    public PeopleModel(IPeopleRepository context)
    {
        _context = context;
    }

    public IList<Person> People { get;set; }

    public async Task OnGetAsync()
    {
        People = await _context.GetPeopleAsync();
    }
}
