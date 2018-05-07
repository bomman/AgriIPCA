namespace AgriIPCA.Models.Products
{
    public class Flower : Plant
    {
        public Flower(string name) : base(name)
        {
        }

        public string Species { get; set; }

        public string Color { get; set; }
    }
}
