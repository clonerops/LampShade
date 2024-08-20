using _0_Framework.Domain;
using AccountManagment.Application.contracts;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        List<AccountViewModel> List();
        AccountViewModel GetBy(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);

    }
}
