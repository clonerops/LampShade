using _0_Framework.Infrastructure;
using DiscountManagment.Application.contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;

namespace DiscountManagment.Infrastructure.EfCore.Repository
{
    public class CustomerDiscountRepository : ReposioryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        public CustomerDiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public List<CustomerDiscountViewModel> List()
        {
            return _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id= x.Id,
                ProductId= x.ProductId,
                DiscountRate= x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate= x.EndDate.ToString(),
                Reason = x.Reason,
            }).ToList();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                Reason = x.Reason,
            });

            if(searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                var startDate = DateTime.Now;
                query = query.Where(x => x.StartDateGR > startDate);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var endDate = DateTime.Now;
                query = query.Where(x => x.EndDateGr > endDate);
            }

            return query.ToList();


        }
    }
}
