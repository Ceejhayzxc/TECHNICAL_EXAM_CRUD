using EXAM.CRUD.Common;
using EXAM.CRUD.Models;

namespace EXAM.CRUD.Interfaces
{
    public interface IPersonsRepository : IBaseRepository<Persons>
    {
        Task<GenericSearch<Persons>> GetSearch(string? search);
    }
}
