﻿namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshRequest
    {
        public string Email { get; set; }

        public string RefreshToken { get; set; }
    }
}