
using _0_Framework.Application;
using DiscountManagment.Application.contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;

namespace DiscountManagment.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Create(CreateCustomerDiscount command)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed("امکان ایجاد رکورد تکراری وجود ندارد");

            var startDate = DateTime.Now;
            var endtDate = DateTime.Now;

            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, startDate, endtDate, command.Reason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();

            var findCustomerDiscount = _customerDiscountRepository.Get(command.Id);
            if (findCustomerDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            var startDate = DateTime.Now;
            var endtDate = DateTime.Now;

            findCustomerDiscount.Edit(command.ProductId, command.DiscountRate, startDate, endtDate, command.Reason);
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<CustomerDiscountViewModel> List()
        {
            return _customerDiscountRepository.List();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var findCustomerDiscount = _customerDiscountRepository.Get(id);
            if (findCustomerDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            findCustomerDiscount.Remove();
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var findCustomerDiscount = _customerDiscountRepository.Get(id);
            if (findCustomerDiscount == null)
                return operation.Failed("رکوردی یافت نشد");

            findCustomerDiscount.Restore();
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
