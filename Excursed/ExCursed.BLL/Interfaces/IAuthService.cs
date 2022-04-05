using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Auth;

namespace ExCursed.BLL.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAdminAsync(AdminRegistrationDTO request);

        Task RegisterUniversityAdminAsync(UniversityAdminRegistrationDTO request);

        Task RegisterTeacherAsync(TeacherRegistrationDTO request);

        Task RegisterStudentAsync(StudentRegistrationDTO request);

        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);

        Task<TokenRefreshResponseDTO> RefreshTokenAsync(TokenRefreshRequestDTO request);

        Task RevokeTokenAsync(TokenRevokeDTO request);

        Task<UserInfoResponseDTO> GetUserInfoAsync(string email);
    }
}