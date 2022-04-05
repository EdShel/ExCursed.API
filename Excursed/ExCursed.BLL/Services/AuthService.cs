﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Auth;
using ExCursed.BLL.Exceptions;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Interfaces;
using ExCursed.DAL.Repositories;

namespace ExCursed.BLL.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserRepository usersRepository;

        private readonly IRepository<University> universityRepository;

        private readonly IRepository<UniversityAdmin> universityAdminRepository;

        private readonly IRepository<Teacher> teachersRepository;

        private readonly IRepository<Student> studentsRepository;

        private readonly IAuthTokenGenerator tokenGenerator;

        private readonly IRefreshTokenFactory refreshTokenFactory;

        public AuthService(
            UserRepository usersRepository,
            IRepository<University> universityRepository,
            IRepository<UniversityAdmin> universityAdminRepository,
            IRepository<Teacher> teachersRepository,
            IRepository<Student> studentsRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.universityAdminRepository = universityAdminRepository;
            this.teachersRepository = teachersRepository;
            this.studentsRepository = studentsRepository;
            this.universityRepository = universityRepository;
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenFactory = refreshTokenFactory;
        }

        #region Registration

        public async Task RegisterAdminAsync(AdminRegistrationDTO request)
        {
            User adminUser = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(adminUser, RoleName.ADMIN);
        }

        public async Task RegisterUniversityAdminAsync(UniversityAdminRegistrationDTO request)
        {
            University university = await universityRepository.GetByIdAsync(request.UniversityId);
            if (university == null)
            {
                throw new BadRequestException("University doesn't exist!");
            }

            User universityAdminUser = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(universityAdminUser, RoleName.UNIVERSITY_ADMIN);
            await universityAdminRepository.AddAsync(new UniversityAdmin
            {
                UserId = universityAdminUser.Id,
                UniversityId = request.UniversityId
            });
            await universityAdminRepository.SaveChangesAsync();
        }

        public async Task RegisterTeacherAsync(TeacherRegistrationDTO request)
        {
            University university = await universityRepository.GetByIdAsync(request.UniversityId);
            if (university == null)
            {
                throw new BadRequestException("University doesn't exist!");
            }

            User teacherUser = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(teacherUser, RoleName.TEACHER);
            await teachersRepository.AddAsync(new Teacher
            {
                UserId = teacherUser.Id,
                UniversityId = request.UniversityId
            });
            await teachersRepository.SaveChangesAsync();
        }

        public async Task RegisterStudentAsync(StudentRegistrationDTO request)
        {
            University university = await universityRepository.GetByIdAsync(request.UniversityId);
            if (university == null)
            {
                throw new BadRequestException("University doesn't exist!");
            }

            User studentUser = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(studentUser, RoleName.STUDENT);
            await studentsRepository.AddAsync(new Student
            {
                UserId = studentUser.Id,
                UniversityId = request.UniversityId
            });
            await studentsRepository.SaveChangesAsync();
        }

        private async Task<User> RegisterAsync(RegistrationDTO request)
        {
            var user = new User
            {
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            var registerResult = await usersRepository.TryCreateAsync(
                user: user,
                password: request.Password);

            if (!registerResult.Succeeded)
            {
                throw new BadRequestException(registerResult.Errors.First().Description);
            }

            return user;
        }

        #endregion

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BadRequestException("User does not exist!");
            }

            bool passwordIsCorrect = await usersRepository.CheckPasswordAsync(user, request.Password);
            if (!passwordIsCorrect)
            {
                throw new ForbiddenException("Password is incorrect!");
            }
            Claim[] userClaims = await GetAuthTokenClaimsForUserAsync(user);

            var accessToken = tokenGenerator.GenerateTokenForClaims(userClaims);
            var refreshToken = refreshTokenFactory.GenerateRefreshToken();
            await usersRepository.CreateRefreshTokenAsync(user, refreshToken);

            return new LoginResponseDTO
            {
                Email = user.Email,
                Token = accessToken,
                RefreshToken = refreshToken
            };
        }

        private async Task<Claim[]> GetAuthTokenClaimsForUserAsync(User user)
        {
            IList<string> userRoles = await usersRepository.GetRolesAsync(user);
            var userClaims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.FirstOrDefault())
            };
            return userClaims;
        }

        public async Task<TokenRefreshResponseDTO> RefreshTokenAsync(TokenRefreshRequestDTO request)
        {
            string userEmail = GetEmailOfAuthorizationToken(request);
            User user = await usersRepository.FindByEmailAsync(userEmail);
            if (user == null)
            {
                throw new BadRequestException("User does not exist!");
            }

            RefreshToken token = usersRepository.GetRefreshToken(user, request.RefreshToken);
            if (token == null)
            {
                throw new ForbiddenException("Refresh token is not valid!");
            }

            var newRefreshToken = refreshTokenFactory.GenerateRefreshToken();
            await usersRepository.DeleteRefreshTokenAsync(token);
            await usersRepository.CreateRefreshTokenAsync(user, newRefreshToken);

            Claim[] tokenClaims = await GetAuthTokenClaimsForUserAsync(user);
            string newAccessToken = tokenGenerator.GenerateTokenForClaims(tokenClaims);

            return new TokenRefreshResponseDTO
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        private static string GetEmailOfAuthorizationToken(TokenRefreshRequestDTO request)
        {
            return new JwtSecurityTokenHandler()
                .ReadJwtToken(request.AuthToken)
                .Claims
                .FirstOrDefault(claim => claim.Type == ClaimsIdentity.DefaultNameClaimType)
                .Value;
        }


        public async Task RevokeTokenAsync(TokenRevokeDTO request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BadRequestException("User does not exist!");
            }

            RefreshToken refreshToken = usersRepository.GetRefreshToken(user, request.RefreshToken);
            if (refreshToken == null)
            {
                throw new ForbiddenException("Refresh token is not valid!");
            }

            await usersRepository.DeleteRefreshTokenAsync(refreshToken);
        }

        public async Task<UserInfoResponseDTO> GetUserInfoAsync(string email)
        {
            var user = await usersRepository.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }

            IList<string> userRoles = await usersRepository.GetRolesAsync(user);
            return new UserInfoResponseDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = userRoles.FirstOrDefault()
            };
        }
    }
}
