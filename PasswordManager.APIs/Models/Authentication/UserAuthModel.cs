﻿namespace PasswordManager.APIs.Models.Authentication
{
    public class UserAuthModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
