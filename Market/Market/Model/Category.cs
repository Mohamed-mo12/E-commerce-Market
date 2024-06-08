namespace Market.Model
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
