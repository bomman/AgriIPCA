using System.IO;
using AgriIPCA.Interfaces;

namespace AgriIPCA.IO
{
    public class PersonsFactory : IFactory
    {
        private const string FileLocation = "../../Database/persons.txt";

        public PersonsFactory()
        {
        }

        public void Write(string output)
        {
            StreamWriter writer = new StreamWriter(FileLocation, append: true);
 
            writer.WriteLine(output);

            writer.Close();
        }

        public string Read()
        {
            StreamReader reader = new StreamReader(FileLocation);
            string input = reader.ReadToEnd();
            reader.Close();

            return input;
        }
    }
}
