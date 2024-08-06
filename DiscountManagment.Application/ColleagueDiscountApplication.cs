using _0_Framework.Application;
using DiscountManagment.Application.contracts.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;

namespace DiscountManagment.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueRepository _colleagueRepository;

        public ColleagueDiscountApplication(IColleagueRepository colleagueRepository)
        {
            _colleagueRepository = colleagueRepository;
        }

        public OperationResult Create(CreateColleagueDiscount command)
        {
            var operation = new OperationResult();
            
            if (_colleagueRepository.Exist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            
            var colleageDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueRepository.Create(colleageDiscount);
            _colleagueRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();

            var findColleagueDiscount = _colleagueRepository.Get(command.Id);

            if (findColleagueDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            findColleagueDiscount.Edit(command.Id, command.DiscountRate);
            _colleagueRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> List()
        {
            return _colleagueRepository.List();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var findColleagueDiscount = _colleagueRepository.Get(id);

            if (findColleagueDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            findColleagueDiscount.Remove();
            _colleagueRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var findColleagueDiscount = _colleagueRepository.Get(id);

            if (findColleagueDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            findColleagueDiscount.Restore();
            _colleagueRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueRepository.Search(searchModel);
        }
    }
}
