namespace EFCore8FullTextIssueExample.Model
{
    public class Store
    {
        public Store()
        {

        }
        public Guid StoreId { get; set; }
        public virtual ICollection<StoreProduct> Products { get; set; }
        public Guid? TenantId { get; set; }
    }
}
