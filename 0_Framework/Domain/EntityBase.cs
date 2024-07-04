namespace _0_Framework.Domain
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public EntityBase()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
