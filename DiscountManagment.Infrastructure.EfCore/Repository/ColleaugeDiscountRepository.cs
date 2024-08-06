using _0_Framework.Infrastructure;
using DiscountManagment.Application.contracts.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;

namespace DiscountManagment.Infrastructure.EfCore.Repository
{
    public class ColleaugeDiscountRepository : ReposioryBase<long, ColleagueDiscount>, IColleagueRepository
    {
        private readonly DiscountContext _context;

        public ColleaugeDiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public List<ColleagueDiscountViewModel> List()
        {
            return _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id = x.Id,
                DiscountRate= x.DiscountRate,
                ProductId = x.ProductId,
            }).ToList();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id = x.Id,
                ProductId= x.ProductId,
                DiscountRate = x.DiscountRate
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.ToList();
        }
    }
}
