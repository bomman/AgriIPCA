namespace AgriIPCA.Interfaces
{
    public interface IFactory : IWriter, IReader
    {
        void Update(string output);
    }
}
