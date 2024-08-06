namespace DiscountManagment.Application.contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public DateTime StartDateGR { get; set; }
        public string StartDate { get; set; }
        public DateTime EndDateGr { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }

    }

}
