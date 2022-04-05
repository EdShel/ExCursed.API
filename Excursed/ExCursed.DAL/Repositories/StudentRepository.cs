using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Interfaces;

namespace ExCursed.DAL.Repositories
{
    public sealed class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await context.Set<Student>().FirstOrDefaultAsync(s => s.UserId == id);
        }
    }
}
