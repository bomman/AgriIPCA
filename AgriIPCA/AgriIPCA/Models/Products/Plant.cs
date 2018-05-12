namespace AgriIPCA.Models.Products
{
    public abstract class Plant : Product
    {
        protected Plant()
        {
            
        }

        protected Plant(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }
    }
}
