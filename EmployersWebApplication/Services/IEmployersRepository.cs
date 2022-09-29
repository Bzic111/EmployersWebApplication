using EmployersWebApplication.Models;

namespace EmployersWebApplication.Services
{
    public interface IEmployersRepository
    {
        IEnumerable<Employer> GetAll();
        Employer? GetById(int id);
        public int Add(Employer employer);
        public bool Edit(Employer employer);
        public bool Remove(int id);
    }
}
