namespace InterfaceSegregation
{
    public interface IStoreWriter
    {
         void Save(int id, string message);
    }
}