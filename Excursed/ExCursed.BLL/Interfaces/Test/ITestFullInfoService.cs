using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestFullInfoService
    {
        Task<TestFullDTO> GetTestFullInfoAsync(int testId);
    }
}
