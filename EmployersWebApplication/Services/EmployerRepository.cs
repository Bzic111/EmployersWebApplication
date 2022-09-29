using EmployersWebApplication.Models;
using EmployersWebApplication.Services;

public class EmployerRepository : IEmployersRepository
{
    private readonly List<Employer> _employers;
    private int _MaxFreeId { get; set; }
    public EmployerRepository()
    {
        _employers = Enumerable.Range(1,10).Select(i=> new Employer
        {
            Id=i,
            LastName = $"Family-{i}",
            FirstName = $"Name-{i}",
            Patronimic = $"Patronimic-{i}",
            Birthday = DateTime.Now.AddYears(-18-i),
        }).ToList();
    }
    public int Add(Employer employer)
    {
        _MaxFreeId = _employers.Max(e => e.Id) + 1;
        employer.Id = _MaxFreeId;
        _employers.Add(employer);
        return _MaxFreeId;
    }

    public bool Remove(int id)
    {
        var temp = GetById(id);
        if (temp is not null)
        {
            _employers.Remove(temp);
            return true;
        }
        return false;
    }

    public bool Edit(Employer employer)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employer> GetAll() => _employers;

    public Employer? GetById(int id)=>_employers.FirstOrDefault(e => e.Id == id);
}