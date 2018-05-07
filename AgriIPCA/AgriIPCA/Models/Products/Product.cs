namespace AgriIPCA.Models.Products
{
    public abstract class Product
    {
        protected Product(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Description}";
        }
    }
}
