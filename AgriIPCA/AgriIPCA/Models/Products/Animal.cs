namespace AgriIPCA.Models.Products
{
    public class Animal : Product
    {
        public Animal(string name) : base(name)
        {
            
        }

        public string Breed { get; set; }
    }
}
