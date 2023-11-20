namespace DapperExample.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
    public class CommandProduct : Product
    {
        public string Action { get; set; }
    }
}
