﻿using Microsoft.AspNetCore.Identity;

namespace ExCursed.BLL.Models
{
    public class RegisterResult
    {
        public string UserId { get; set; } = null;

        public IdentityResult IdentityResult { get; set; }

        public RegisterResult(IdentityResult identityResult)
        {
            IdentityResult = identityResult;
        }
    }
}
