using EXAM.CRUD.Common;
using EXAM.CRUD.Data;
using EXAM.CRUD.Interfaces;
using EXAM.CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.CRUD.Repositories
{
    public class PersonsRepository : BaseRepository<Persons>, IPersonsRepository
    {
        public PersonsRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<GenericSearch<Persons>> GetSearch(string? search)
        {
            var query = _table.Where(p => p.IsActive && !p.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.firstName.Contains(search) ||
                    p.lastName.Contains(search) ||
                    p.Email.Contains(search));
            }

            return new GenericSearch<Persons>
            {
                SearchKeyword = search,
                Results = await query.ToListAsync()
            };
        }
    }
}
