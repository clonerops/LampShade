
using _0_Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }

        public Account(string firstName, string lastName, string userName, string password, 
            string email, string mobile, long roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            Mobile = mobile;
            RoleId = roleId;
        }

        public void Edit(string firstName, string lastName, string userName, string password,
            string email, string mobile, long roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            Mobile = mobile;
            RoleId = roleId;

        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
