using _0_Framework.Application;

namespace AccountManagment.Application.contracts
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<AccountViewModel> List();
        AccountViewModel GetBy(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
