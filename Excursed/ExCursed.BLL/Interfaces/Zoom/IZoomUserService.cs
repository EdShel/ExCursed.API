using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Zoom;

namespace ExCursed.BLL.Interfaces.Zoom
{
    public interface IZoomUserService
    {
        Task<ZoomUserInfoDTO> GetUserInfoAsync();
    }
}
