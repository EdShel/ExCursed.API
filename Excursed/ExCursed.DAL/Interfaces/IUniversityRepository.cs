using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.DAL.Entities;

namespace ExCursed.DAL.Interfaces
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<bool> HasUniversityAdminAsync(int universityId, string userName);

        Task<bool> HasTeacherAsync(int universityId, string userName);

        Task<bool> HasStudentAsync(int universityId, string userName);
    }
}
