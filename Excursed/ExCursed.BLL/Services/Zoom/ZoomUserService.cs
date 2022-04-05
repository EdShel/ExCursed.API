using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Zoom;
using ExCursed.BLL.Interfaces.Zoom;

namespace ExCursed.BLL.Services.Zoom
{
    public class ZoomUserService : IZoomUserService
    {
        private readonly ZoomClient userClient;

        public ZoomUserService(ZoomUserClient userClient)
        {
            this.userClient = userClient;
        }

        public async Task<ZoomUserInfoDTO> GetUserInfoAsync()
        {
            var response = await userClient
                .GetDeserializedAsync<ZoomUserInfoDTO>("v2/users/me", null);
            ZoomUserInfoDTO userInfo = response.Body;
            return userInfo;
        }
    }
}
