using System;
using AgriIPCA.Interfaces;

namespace AgriIPCA.IO
{
    public class ProductsFactory : IFactory
    {
        private const string FileLocation = "../../../Database/persons.txt";

        public ProductsFactory()
        {
            
        }

        public void Write(string output)
        {
            throw new NotImplementedException();
        }

        public string Read()
        {
            throw new NotImplementedException();
        }
    }
}
