using System.Threading.Tasks;
using ExCursed.DAL.Entities;

namespace ExCursed.DAL.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetByIdAsync(string id);

        Task<Teacher> GetByEmailAsync(string emaiil);
    }
}
