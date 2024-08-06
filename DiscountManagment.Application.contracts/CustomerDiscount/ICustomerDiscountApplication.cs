

using _0_Framework.Application;

namespace DiscountManagment.Application.contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        List<CustomerDiscountViewModel> List();
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
