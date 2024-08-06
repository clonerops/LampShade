using _0_Framework.Domain;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBase<long>
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsDeleted= false;
        }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
