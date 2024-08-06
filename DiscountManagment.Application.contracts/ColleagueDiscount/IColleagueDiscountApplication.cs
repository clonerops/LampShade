using _0_Framework.Application;

namespace DiscountManagment.Application.contracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        List<ColleagueDiscountViewModel> List();
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
