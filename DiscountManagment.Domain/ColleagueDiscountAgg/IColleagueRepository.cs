using _0_Framework.Domain;
using DiscountManagment.Application.contracts.ColleagueDiscount;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public interface IColleagueRepository : IRepository<long, ColleagueDiscount>
    {
        List<ColleagueDiscountViewModel> List();
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
