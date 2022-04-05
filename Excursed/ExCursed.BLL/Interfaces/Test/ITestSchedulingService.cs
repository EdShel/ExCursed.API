using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Test;

namespace ExCursed.BLL.Interfaces.Test
{
    public interface ITestSchedulingService
    {
        Task<int> ScheduleTestAsync(TestScheduleCreateDTO createDTO);

        Task RemoveTestFromScheduleAsync(int scheduleId);

        Task EditTestScheduleAsync(TestScheduleEditDTO editDTO);

        Task<TestScheduleDTO> GetTestScheduleAsync(int scheduleId);
    }
}
