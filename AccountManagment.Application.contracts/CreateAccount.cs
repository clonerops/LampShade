﻿namespace AccountManagment.Application.contracts
{
    public class CreateAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }

    }
}