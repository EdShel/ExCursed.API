using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.UniversityRequest;

namespace ExCursed.BLL.Interfaces
{
    public interface IUniversityRequestService
    {
        Task AddRequestAsync(UniversityCreateRequestDTO creationInfo);

        Task<IEnumerable<UniversityCreateRequestViewDTO>> GetAllRequestsAsync();

        Task ApproveRequestAsync(int id);

        Task RejectRequestAsync(int id);
    }
}
