
using _0_Framework.Domain;

namespace InventoryManagment.Domain.InventoryAgg
{
    //پیاده سازی بخش دامین انبار
    public class Inventory : EntityBase<long>
    {
        public long ProductId { get; set; } //مشخص می کنیم این انبار برای کدوم محصول است.
        public double UnitPrice { get; set; } //قیمت محصول در انبار چقدر است
        public bool InStock { get; set; } //آیا از این محصول در انبار موجود دارم یا نه؟
        public List<InventoryOperation> Operations { get; set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice; 
            InStock = false;
        }

        //محاسبه مقدار فعلی در انبار
        public long CalculateCurrentCount()
        {
            //باید مقدار افزایش موجودی و کاهش موجودی را بگیریم و از همدیگه کم کنیم

            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);

            return plus - minus;
        }

        //محسابه افزایش موجودی 
        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, operatorId, count, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        // محاسبه کاهش موجودی
        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(true, operatorId, count, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }

    //ما لاگ عملیات های انبار را نیاز داریم برای کاهش یا افزایش موجودی در انبار
    public class InventoryOperation
    {
        public long Id { get; set; }
        public bool Operation { get; set; } //نوع عملیات را مشخص می کند که آیا از انبار خارج شده یا وارد شده
        public long OperatorId { get; set; } //مشخص می کند که چه کسی این عملیات را انجام داده است
        public long Count { get; set; } //تعداد تغییر را مشخص می کنیم که چه مقدار وارد یا خارج شده
        public DateTime OperationDate { get; set; } //مشخص می کند در چه تاریخی این عملیات انجام شده
        public long CurrentCount { get; set; } //در تاریخی که این عملیات اناجم شده موجودی انبار چقدر بوده است
        public string Description { get; set; }
        public long OrderId { get; set; } //اگر سفارشی از سمت مشتری بوده شماره سفارش را وارد کنیم
        public long InventoryId { get; set; } //مشخص می کنیم این عملیات مربوط به چه انباری بوده 
        public Inventory Inventory { get; set; }

        public InventoryOperation(bool operation, long operatorId, long count, long currentCount, 
            string description, long orderId, long inventoryId)
        {
            Operation = operation;
            OperatorId = operatorId;
            Count = count;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }
    }


}


