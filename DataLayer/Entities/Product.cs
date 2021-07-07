namespace DataLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre CategoryId { get; set; }
        public Company CompanyId { get; set; }
    }
}
