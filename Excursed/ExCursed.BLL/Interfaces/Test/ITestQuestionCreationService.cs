using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestQuestionCreationService
    {
        Task<int> CreateQuestionAsync(TestQuestionCreateDTO createDTO);

        Task DeleteQuestionAsync(int questionId);

        Task EditQuestionAsync(TestQuestionEditDTO editDTO);

        Task<TestQuestionDTO> GetQuestionAsync(int questionId);
    }
}
