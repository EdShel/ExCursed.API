﻿namespace ExCursed.WebAPI.Models.Users
{
    public sealed class AdminRegistrationRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
