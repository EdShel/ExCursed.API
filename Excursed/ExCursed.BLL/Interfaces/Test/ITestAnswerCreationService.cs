using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestAnswerCreationService
    {
        Task<int> CreateAnswerVariantAsync(TestAnswerVariantCreateDTO createDTO);

        Task DeleteAnswerVariantAsync(int answerId);

        Task EditAnswerVariantAsync(TestAnswerVariantEditDTO editDTO);

        Task<TestAnswerVariantDTO> GetAnswerVariantAsync(int answerId);
    }
}
