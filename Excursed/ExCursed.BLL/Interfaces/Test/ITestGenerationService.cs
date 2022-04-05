using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;
using TestEntity = ExCursed.DAL.Entities.Tests.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestGenerationService
    {
        Task<TestTakingDTO> GenerateTestAsync(TestEntity test);
    }
}
