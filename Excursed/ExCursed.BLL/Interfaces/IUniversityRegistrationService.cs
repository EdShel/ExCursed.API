using System.Threading.Tasks;
using ExCursed.BLL.DTOs.UniversityRequest;

namespace ExCursed.BLL.Interfaces
{
    public interface IUniversityRegistrationService
    {
        Task<UniversityCreationResultDTO> CreateUniversityAsync(UniversityCreateRequestViewDTO createRequestDTO);
    }
}
