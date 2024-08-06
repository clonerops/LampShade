using _0_Framework.Domain;
using DiscountManagment.Application.contracts.CustomerDiscount;

namespace DiscountManagment.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscount>
    {
        List<CustomerDiscountViewModel> List();
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
