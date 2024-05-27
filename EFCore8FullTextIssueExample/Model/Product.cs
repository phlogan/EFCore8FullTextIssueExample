namespace EFCore8FullTextIssueExample.Model
{
    public class Product
    {
        public Product()
        {

        }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StoreProduct> Stores { get; set; }
        public Guid? TenantId { get; set; }
    }
}
