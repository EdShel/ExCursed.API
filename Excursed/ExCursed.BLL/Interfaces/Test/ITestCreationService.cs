using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestCreationService
    {
        Task<int> CreateTestAsync(TestCreateDTO createDTO);

        Task DeleteTestAsync(int testId);

        Task EditTestAsync(TestEditDTO editDTO);

        Task<TestDTO> GetTestAsync(int testId);
    }
}
