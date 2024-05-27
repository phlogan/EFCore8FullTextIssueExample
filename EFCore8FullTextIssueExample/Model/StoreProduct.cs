namespace EFCore8FullTextIssueExample.Model
{
    public class StoreProduct
    {
        public Guid StoreProductId { get; set; }
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid? TenantId { get; set; }
    }
}
