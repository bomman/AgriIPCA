namespace AgriIPCA.Models.Products
{
    public abstract class Plant : Product
    {
        protected Plant(string name, decimal price) : base(name, price)
        {
        }
    }
}
