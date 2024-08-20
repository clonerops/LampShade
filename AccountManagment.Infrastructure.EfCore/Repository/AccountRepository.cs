using _0_Framework.Infrastructure;
using AccountManagement.Domain.AccountAgg;
using AccountManagment.Application.contracts;

namespace AccountManagment.Infrastructure.EfCore.Repository
{
    public class AccountRepository : ReposioryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public AccountViewModel GetBy(long id)
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Mobile = x.Mobile,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> List()
        {
            return _context.Accounts.Select(x => new AccountViewModel 
            { 
                Id = x.Id,
                FirstName= x.FirstName,
                LastName = x.LastName,
                Email= x.Email,
                Mobile= x.Mobile,
                UserName= x.UserName,

            }).ToList();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Mobile = x.Mobile,
                UserName = x.UserName,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.FirstName) || !string.IsNullOrEmpty(searchModel.LastName))
                query = query.Where(x => x.FirstName.Contains(searchModel.FirstName) || x.LastName.Contains(searchModel.LastName));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if(searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}
