using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using AccountManagment.Application.contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AccountManagment.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(command.Id);

            if(account == null)
                return operation.Failed("کاربر یافت نشد");

            if(command.Password != command.ConfirmPassword)
                return operation.Failed("کلمه عبور و تکرار آن برابر نیستند");

            var password = _passwordHasher.Hash(command.Password);

            account.ChangePassword(password);

            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var opeartion = new OperationResult();

            if (_accountRepository.Exist(x => x.UserName == command.UserName))
                return opeartion.Failed("کاربر بااین نام کاربری قبلا در سامانه ثبت شده است");

            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.FirstName, command.LastName, command.UserName, password,
                command.Email, command.Mobile, command.RoleId);

            _accountRepository.Create(account);

            _accountRepository.SaveChanges();

            return opeartion.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed("کاربر یافت نشد");

            var password = _passwordHasher.Hash(command.Password);

            account.Edit(command.FirstName, command.LastName, command.UserName, password,
                command.Email, command.Mobile, command.RoleId);

            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public AccountViewModel GetBy(long id)
        {
            return _accountRepository.GetBy(id);
        }

        public List<AccountViewModel> List()
        {
            return _accountRepository.List();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(id);

            if (account == null)
                return operation.Failed("کاربر یافت نشد");

            account.Remove();

            _accountRepository.SaveChanges();

            return operation.Succedded();


        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(id);

            if (account == null)
                return operation.Failed("کاربر یافت نشد");

            account.Restore();

            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}