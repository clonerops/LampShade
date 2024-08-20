namespace AccountManagment.Application.contracts
{
    public class ChangePassword
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
